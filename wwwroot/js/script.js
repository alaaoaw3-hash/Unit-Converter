document.addEventListener('DOMContentLoaded', () => {
    // State
    let currentUnit = 'Length';

    const unitsMap = {
        'Length': ['mm', 'cm', 'm', 'km', 'in', 'ft', 'yd', 'mi'],
        'Weight': ['mg', 'g', 'kg', 't', 'oz', 'lb'],
        'Temperature': ['°C', '°F', 'K']
    };

    // DOM Elements
    const tabs = document.querySelectorAll('.tab-btn');
    const inputValue = document.getElementById('inputValue');
    const convertBtn = document.getElementById('convertBtn');
    const inputDisplay = document.getElementById('inputDisplay');
    const outputDisplay = document.getElementById('outputDisplay');
    const inputLabel = document.getElementById('inputLabel');

    // Custom Dropdown Elements
    const fromUnit = document.getElementById('fromUnit');
    const toUnit = document.getElementById('toUnit');
    const fromUnitLabel = document.getElementById('fromUnitLabel');
    const toUnitLabel = document.getElementById('toUnitLabel');
    const fromUnitTrigger = document.getElementById('fromUnitTrigger');
    const toUnitTrigger = document.getElementById('toUnitTrigger');
    const fromUnitMenu = document.getElementById('fromUnitMenu');
    const toUnitMenu = document.getElementById('toUnitMenu');
    const fromUnitWrapper = document.getElementById('fromUnitWrapper');
    const toUnitWrapper = document.getElementById('toUnitWrapper');
    const inputUnitLabel = document.getElementById('inputUnitLabel');
    const outputUnitLabel = document.getElementById('outputUnitLabel');

    function populateDropdowns(unitType) {
        const units = unitsMap[unitType];

        const createOptions = (menu, label, hiddenInput, wrapper) => {
            menu.innerHTML = '';
            units.forEach((u, index) => {
                const opt = document.createElement('div');
                opt.className = 'dropdown-option';
                opt.textContent = u;
                opt.onclick = (e) => {
                    e.stopPropagation();
                    label.textContent = u;
                    hiddenInput.value = u;

                    // Update output card labels
                    if (hiddenInput.id === 'fromUnit') {
                        inputUnitLabel.textContent = u;
                    } else {
                        outputUnitLabel.textContent = u;
                    }

                    menu.classList.add('hidden');
                    wrapper.classList.remove('is-open');
                };
                menu.appendChild(opt);
            });
        };

        createOptions(fromUnitMenu, fromUnitLabel, fromUnit, fromUnitWrapper);
        createOptions(toUnitMenu, toUnitLabel, toUnit, toUnitWrapper);

        // Set defaults
        fromUnitLabel.textContent = units[0];
        fromUnit.value = units[0];
        inputUnitLabel.textContent = units[0];
        if (units.length > 1) {
            toUnitLabel.textContent = units[1];
            toUnit.value = units[1];
            outputUnitLabel.textContent = units[1];
        } else {
            toUnitLabel.textContent = units[0];
            toUnit.value = units[0];
            outputUnitLabel.textContent = units[0];
        }
    }

    // Initialize dropdowns
    populateDropdowns(currentUnit);

    // Handle Custom Dropdown Toggles
    const setupCustomDropdown = (trigger, menu, wrapper) => {
        trigger.onclick = (e) => {
            e.stopPropagation();
            const isHidden = menu.classList.contains('hidden');

            // Close other menus
            document.querySelectorAll('.dropdown-menu').forEach(m => m.classList.add('hidden'));
            document.querySelectorAll('.select-wrapper').forEach(w => w.classList.remove('is-open'));

            if (isHidden) {
                menu.classList.remove('hidden');
                wrapper.classList.add('is-open');
            }
        };
    };

    setupCustomDropdown(fromUnitTrigger, fromUnitMenu, fromUnitWrapper);
    setupCustomDropdown(toUnitTrigger, toUnitMenu, toUnitWrapper);

    // Close menus when clicking outside
    document.addEventListener('click', () => {
        document.querySelectorAll('.dropdown-menu').forEach(m => m.classList.add('hidden'));
        document.querySelectorAll('.select-wrapper').forEach(w => w.classList.remove('is-open'));
    });

    // Handle Tab Switching
    tabs.forEach(tab => {
        tab.addEventListener('click', () => {
            currentUnit = tab.dataset.unit;

            // Update visual state of tabs
            tabs.forEach(t => {
                if (t === tab) {
                    t.classList.remove('text-gray-300');
                    t.classList.add('text-black');
                } else {
                    t.classList.remove('text-black');
                    t.classList.add('text-gray-300');
                }
            });

            // Update label and populate dynamic dropdowns
            inputLabel.textContent = `Enter ${currentUnit} to convert`;
            populateDropdowns(currentUnit);

            // Reset UI outputs on tab change
            inputDisplay.textContent = '0';
            outputDisplay.textContent = '0.00';
            inputValue.value = '';
        });
    });

    // Handle Conversion (Mocking Backend)
    convertBtn.addEventListener('click', async () => {
        const valRaw = inputValue.value.trim();     // <-- this is a string
        const val = parseFloat(valRaw);     // <-- this gotten string turned into a float

        // If input is empty or invalid, reset or do nothing
        if (isNaN(val)) {
            inputDisplay.textContent = '0';
            outputDisplay.textContent = '0.00';
            return;
        }

        // Show immediate loading state
        inputDisplay.textContent = val.toString();
        outputDisplay.textContent = '...';

        // send input and units to the backend
        console.log("numberObj will be sent as a POST request.")
        let sendingInfo = await fetch("/api/convertNumber", {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify({
                "UnitType": currentUnit,
                "Number": val,
                "CurrentUnit": fromUnit.value.trim(),
                "TargetUnit": toUnit.value.trim()
            })
        })

        if (sendingInfo.ok) {
            let result = await sendingInfo.json();
            outputDisplay.textContent = result;
        } else {
            outputDisplay.textContent = "Error";
        }
    });

    // Optional: trigger convert on 'Enter' key press
    inputValue.addEventListener('keypress', (e) => {
        if (e.key === 'Enter') {
            convertBtn.click();
        }
    });
});

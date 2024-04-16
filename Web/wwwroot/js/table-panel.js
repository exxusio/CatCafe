let reservationTablesContainer;

function AddTable() {
    const reservationButton = document.getElementById('reservation-table');
    const reservationPanel = document.querySelector('.reservation-table');

    reservationButton.addEventListener('click', function () {
        /*const*/ reservationTablesContainer = document.createElement('div');

        reservationTablesContainer.innerHTML = `
        <div class="object" data-type="mobile">
                <div class="frame">
                    <div class="window" data-type="table">
                        <button class="close" data-type="table">
                            <svg width="25" height="25" viewBox="0 0 25 25" fill="none">
                                <path fill-rule="evenodd" clip-rule="evenodd" fill="#fff" d="M9.61 12.199L.54 3.129A1.833 1.833 0 113.13.536l9.07 9.07L21.27.54a1.833 1.833 0 012.592 2.592l-9.068 9.068 9.07 9.07a1.833 1.833 0 01-2.59 2.592l-9.072-9.07-9.073 9.073a1.833 1.833 0 01-2.591-2.592L9.61 12.2z"></path>
                            </svg>
                        </button>
                        
                        
                            <div class="table-frame">
                                <div class="wall-up"></div>
                                <div class="wall-all">
                                    <div class="wall-left">
                                        <div class="wall-1" data-type="left"></div>
                                        <div class="wall-1" data-type="bottom"></div>
                                        <div class="wall-1" data-type="right"></div>
                                    </div>
                                    <div class="wall-center">
                                        <div class="wall-door">
                                            <div class="title-door">вход</div>
                                        </div>
                                    </div>
                                    <div class="wall-right">
                                        <div class="wall-2" data-type="left"></div>
                                        <div class="wall-2" data-type="bottom"></div>
                                        <div class="wall-2" data-type="right"></div>
                                    </div>
                                </div>
                                <div class="table-in">
                                    
                                </div>
                            </div>

                        <footer class="buttons">
                            <button class="button" type="button" data-type="primary" data-size="medium">Подтвердить</button>
                        </footer>
                    </div>
                </div>
            </div>
        `;

        reservationPanel.appendChild(reservationTablesContainer);



        const monthSelect = document.querySelector('.input.month');
        const daySelect = document.querySelector('.input.day');


        const selectElement = document.getElementById('booking-time');

        const formData = new FormData();

        formData.append('month', monthSelect.value);
        formData.append('day', daySelect.value);
        formData.append('time', selectElement.value);

        fetch(`/CheckTables`, {
            method: 'PUT',
            body: formData
        })
            .then(response => {
                return response.json();
            })
            .then(data => {
                CreateCafeTable(data);
            });




        setTimeout(() => {
            const reservationPanel = reservationTablesContainer.querySelector('.object[data-type="mobile"]');
            reservationPanel.style.transition = 'transform 300ms ease-out';
            reservationPanel.style.transform = 'translateY(0px)';
        }, 100);

        const reservationCloseButton = reservationTablesContainer.querySelector('.close');
        reservationCloseButton.addEventListener('click', closereservation);

        //function closereservation() {
        //    const reservationPanel = reservationContainer.querySelector('.object[data-type="mobile"]');
        //    reservationPanel.style.transform = 'translateY(-100%)';

        //    setTimeout(() => {
        //        reservationContainer.remove();
        //    }, 300);
        //}


        AcceptSelectTable(reservationTablesContainer);
    });
}

function closereservation() {
    const reservationPanel = reservationTablesContainer.querySelector('.object[data-type="mobile"]');
    reservationPanel.style.transform = 'translateY(-100%)';

    setTimeout(() => {
        reservationTablesContainer.remove();
    }, 300);
}



function CreateCafeTable(tables) {
    var tableIn = document.querySelector('.table-in');
    var tableLeft;
    var tableRight;

    var blockA;
    var blockB;
    var blockC;
    var blockD;

    var tableINT = 1;

    tables.forEach(table => {
        if (tableINT === 1) {
            tableLeft = document.createElement('div');
            tableLeft.className = 'table-left';
            blockA = document.createElement('div');
            blockA.className = 'table-A';
        }
        else if (tableINT === 10) {
            tableRight = document.createElement('div');
            tableRight.className = 'table-right';
            blockB = document.createElement('div');
            blockB.className = 'table-B';
        }
        else if (tableINT === 12) {
            blockC = document.createElement('div');
            blockC.className = 'table-C';
        }
        else if (tableINT === 15) {
            blockD = document.createElement('div');
            blockD.className = 'table-D';
        }


        if (tableINT >= 1 && tableINT < 10) {
            blockA.innerHTML += `
            <div class="A-${tableINT}">
                <input class="table-checkbox" type="checkbox" id="A-${table.id}" data-type="table">
                <label class="table" for="A-${table.id}" data-type="table">
                    <span class="table-title">${table.capacity} чел.</span>
                </label>
            </div>
            `;
            if (!table.availability) {
                const input = blockA.querySelector(`#A-${table.id}`);
                input.disabled = true;
            }
        }
        else if (tableINT >= 10 && tableINT < 12) {
            blockB.innerHTML += `
            <div class="B-${tableINT - 9}">
                <input class="table-checkbox" type="checkbox" id="B-${table.id}" data-type="table">
                <label class="table" for="B-${table.id}" data-type="table">
                    <span class="table-title">${table.capacity} чел.</span>
                </label>
            </div>
            `;
            if (!table.availability) {
                const input = blockB.querySelector(`#B-${table.id}`);
                input.disabled = true;
            }
        }
        else if (tableINT >= 12 && tableINT < 15) {
            blockC.innerHTML += `
            <div class="C-${tableINT - 11}">
                <input class="table-checkbox" type="checkbox" id="C-${table.id}" data-type="table">
                <label class="table" for="C-${table.id}" data-type="table">
                    <span class="table-title">${table.capacity} чел.</span>
                </label>
            </div>
            `;
            if (!table.availability) {
                const input = blockC.querySelector(`#C-${table.id}`);
                input.disabled = true;
            }
        }
        else if (tableINT >= 15 && tableINT < 18) {
            blockD.innerHTML += `
            <div class="D-${tableINT - 14}">
                <input class="table-checkbox" type="checkbox" id="D-${table.id}" data-type="table">
                <label class="table" for="D-${table.id}" data-type="table">
                    <span class="table-title">${table.capacity} чел.</span>
                </label>
            </div>
            `;
            if (!table.availability) {
                const input = blockD.querySelector(`#D-${table.id}`);
                input.disabled = true;
            }
        }
        if (tableINT > 18) {
            return;
        }
        tableINT += 1;
    });


    if (blockA !== undefined) {
        tableLeft.appendChild(blockA);
    }
    if (blockB !== undefined) {
        tableRight.appendChild(blockB);
    }
    if (blockC !== undefined) {
        tableRight.appendChild(blockC);
    }
    if (blockD !== undefined) {
        tableRight.appendChild(blockD);
    }
    if (tableLeft !== undefined) {
        tableIn.appendChild(tableLeft);
    }
    if (tableRight !== undefined) {
        tableIn.appendChild(tableRight);
    }

    function limitCheckboxSelection() {
        var checkboxes = document.querySelectorAll('.table-checkbox:checked');
        var maxAllowed = 3;

        if (checkboxes.length > maxAllowed) {
            this.checked = false;
        }
    }

    var checkboxes = document.querySelectorAll('.table-checkbox');
    checkboxes.forEach(function (checkbox) {
        checkbox.addEventListener('change', limitCheckboxSelection);
    });
}




function AcceptSelectTable() {
    const windowTable = document.querySelector('.window[data-type="table"]');
    const confirmButton = windowTable.querySelector('.button[data-type="primary"]');

    confirmButton.addEventListener('click', function () {
        const checkboxes = document.querySelectorAll('.table-checkbox');

        const selectedIds = [];

        checkboxes.forEach(checkbox => {
            if (checkbox.checked) {
                const idNumber = parseInt(checkbox.id.split('-')[1]);
                selectedIds.push(idNumber);
            }
        });

        if (selectedIds.length !== 0) {
            const tableButton = document.getElementById('reservation-table');
            tableButton.textContent = '';
            selectedIds.forEach(item => {
                tableButton.textContent += item + ", ";
            })
            tableButton.textContent = (tableButton.textContent).substring(0, (tableButton.textContent).length - 2);
            closereservation();
        }
    });
}
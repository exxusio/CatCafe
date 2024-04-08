function AddTable() {
    const reservationButton = document.getElementById('reservation-table');
    const reservationPanel = document.querySelector('.reservation-table');

    reservationButton.addEventListener('click', function() {
        const reservationContainer = document.createElement('div');

        reservationContainer.innerHTML = `
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
                                    <div class="table-left">
                                        <div class="table-A">
                                            <div class="A-1">
                                                <input class="table-checkbox" type="checkbox" id="A-1" data-type="table">
                                                <label class="table" for="A-1" data-type="table">
                                                    <span class="table-title">text</span>
                                                </label>
                                            </div>
                                            <div class="A-2">
                                                <input class="table-checkbox" type="checkbox" id="A-2" data-type="table">
                                                <label class="table" for="A-2" data-type="table">
                                                    <span class="table-title">text</span>
                                                </label>
                                            </div>
                                            <div class="A-3">
                                                <input class="table-checkbox" type="checkbox" id="A-3" data-type="table">
                                                <label class="table" for="A-3" data-type="table">
                                                    <span class="table-title">text</span>
                                                </label>
                                            </div>
                                            <div class="A-4">
                                                <input class="table-checkbox" type="checkbox" id="A-4" data-type="table">
                                                <label class="table" for="A-4" data-type="table">
                                                    <span class="table-title">text</span>
                                                </label>
                                            </div>
                                            <div class="A-5">
                                                <input class="table-checkbox" type="checkbox" id="A-5" data-type="table">
                                                <label class="table" for="A-5" data-type="table">
                                                    <span class="table-title">text</span>
                                                </label>
                                            </div>
                                            <div class="A-6">
                                                <input class="table-checkbox" type="checkbox" id="A-6" data-type="table">
                                                <label class="table" for="A-6" data-type="table">
                                                    <span class="table-title">text</span>
                                                </label>
                                            </div>
                                            <div class="A-7">
                                                <input class="table-checkbox" type="checkbox" id="A-7" data-type="table">
                                                <label class="table" for="A-7" data-type="table">
                                                    <span class="table-title">text</span>
                                                </label>
                                            </div>
                                            <div class="A-8">
                                                <input class="table-checkbox" type="checkbox" id="A-8" data-type="table">
                                                <label class="table" for="A-8" data-type="table">
                                                    <span class="table-title">text</span>
                                                </label>
                                            </div>
                                            <div class="A-9">
                                                <input class="table-checkbox" type="checkbox" id="A-9" data-type="table">
                                                <label class="table" for="A-9" data-type="table">
                                                    <span class="table-title">text</span>
                                                </label>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="table-right">
                                        <div class="table-B">
                                            <div class="B-1">
                                                <input class="table-checkbox" type="checkbox" id="B-1" data-type="table">
                                                <label class="table" for="B-1" data-type="table">
                                                    <span class="table-title">text</span>
                                                </label>
                                            </div>
                                            <div class="B-2">
                                                <input class="table-checkbox" type="checkbox" id="B-2" data-type="table">
                                                <label class="table" for="B-2" data-type="table">
                                                    <span class="table-title">text</span>
                                                </label>
                                            </div>
                                        </div>
                                        <div class="table-C">
                                            <div class="C-1">
                                                <input class="table-checkbox" type="checkbox" id="C-1" data-type="table">
                                                <label class="table" for="C-1" data-type="table">
                                                    <span class="table-title">text</span>
                                                </label>
                                            </div>
                                            <div class="C-2">
                                                <input class="table-checkbox" type="checkbox" id="C-2" data-type="table">
                                                <label class="table" for="C-2" data-type="table">
                                                    <span class="table-title">text</span>
                                                </label>
                                            </div>
                                            <div class="C-3">
                                                <input class="table-checkbox" type="checkbox" id="C-3" data-type="table">
                                                <label class="table" for="C-3" data-type="table">
                                                    <span class="table-title">text</span>
                                                </label>
                                            </div>
                                        </div>
                                        <div class="table-D">
                                            <div class="D-1">
                                                <input class="table-checkbox" type="checkbox" id="D-1" data-type="table">
                                                <label class="table" for="D-1" data-type="table">
                                                    <span class="table-title">text</span>
                                                </label>
                                            </div>
                                            <div class="D-2">
                                                <input class="table-checkbox" type="checkbox" id="D-2" data-type="table">
                                                <label class="table" for="D-2" data-type="table">
                                                    <span class="table-title">text</span>
                                                </label>
                                            </div>
                                            <div class="D-3">
                                                <input class="table-checkbox" type="checkbox" id="D-3" data-type="table">
                                                <label class="table" for="D-3" data-type="table">
                                                    <span class="table-title">text</span>
                                                </label>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>

                        <footer class="buttons">
                            <button class="button" type="button" data-type="primary" data-size="medium">Подтвердить</button>
                        </footer>
                    </div>
                </div>
            </div>
        `;

        reservationPanel.appendChild(reservationContainer);

        setTimeout(() => {
            const reservationPanel = reservationContainer.querySelector('.object[data-type="mobile"]');
            reservationPanel.style.transition = 'transform 300ms ease-out';
            reservationPanel.style.transform = 'translateY(0px)';
        }, 100);
        
        const reservationCloseButton = reservationContainer.querySelector('.close');
        reservationCloseButton.addEventListener('click', closereservation);

        function closereservation() {
            const reservationPanel = reservationContainer.querySelector('.object[data-type="mobile"]');
            reservationPanel.style.transform = 'translateY(-100%)';
        
            setTimeout(() => {
                reservationContainer.remove();
            }, 300);
        }


        function limitCheckboxSelection() {
            var checkboxes = document.querySelectorAll('.table-checkbox:checked');
            var maxAllowed = 3;
        
            if (checkboxes.length > maxAllowed) {
                this.checked = false;
            }
        }
        
        var checkboxes = document.querySelectorAll('.table-checkbox');
        
        checkboxes.forEach(function(checkbox) {
            checkbox.addEventListener('change', limitCheckboxSelection);
        });
    });
}
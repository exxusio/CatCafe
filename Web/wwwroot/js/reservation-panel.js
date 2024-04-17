let reservationContainer;

document.addEventListener('DOMContentLoaded', function () {
    const reservationButton = document.getElementById('reservation');
    const reservationPanel = document.querySelector('.reservation-window');

    reservationButton.addEventListener('click', function () {
        /*const*/ reservationContainer = document.createElement('div');

        reservationContainer.innerHTML = `
        <div class="background" style="opacity: 0;"></div>
            <div class="object" data-type="mobile">
                <div class="frame">
                    <div class="window" data-type="reservation">
                        <button class="close" data-type="reservation">
                            <svg width="25" height="25" viewBox="0 0 25 25" fill="none">
                                <path fill-rule="evenodd" clip-rule="evenodd" fill="#fff" d="M9.61 12.199L.54 3.129A1.833 1.833 0 113.13.536l9.07 9.07L21.27.54a1.833 1.833 0 012.592 2.592l-9.068 9.068 9.07 9.07a1.833 1.833 0 01-2.59 2.592l-9.072-9.07-9.073 9.073a1.833 1.833 0 01-2.591-2.592L9.61 12.2z"></path>
                            </svg>
                        </button>
                        <div class="info">
                            <div class="title">Забронировать столик</div>
                        </div>
                        <div>
                            <div class="form" date-type="date">
                                <label for="" class="container">
                                    <span class="label">Дата</span>
                                        <div class="container" id="reservation-date">
                                        <!-- Здесь будет создано поле для ввода даты -->
                                        </div>
                                </label>
                            </div>

                            <div class="form" date-type="time" id="reservation-time">
                                <label for="" class="container">
                                        <span class="label">Время</span>
                                        <div class="container">
                                            <select class="input" id="booking-time" name="booking-time" required>
                                                <option value="" selected disabled>Время</option>
                                            </select>
                                        </div>
                                </label>
                            </div>

                            <div class="form">
                                <label for="" class="container">
                                        <span class="label">Столики</span>
                                        <div class="container">
                                            <button class="input" id="reservation-table" disabled></button>
                                        </div>
                                </label>
                            </div>
                            
                            <div class="form">
                                <div class="container">
                                        <span class="label">Котики</span>
                                        <div class="container">
                                            <div class="cats-list">

                                                
                                                
                                              </div>
                                        </div>
                                </div>
                            </div>

                        </div>
                        <footer class="buttons">
                            <button class="button" type="button" data-type="primary" data-size="medium" id="addReservation">Подтвердить</button>
                        </footer>
                    </div>
                </div>
            </div>
        `;

        reservationPanel.appendChild(reservationContainer);

        SetData();
        setTimeout(() => {
            const reservationPanel = reservationContainer.querySelector('.object[data-type="mobile"]');
            background.style.transition = 'opacity 300ms ease-out';
            reservationPanel.style.transition = 'transform 300ms ease-out';
            background.style.opacity = '1';
            reservationPanel.style.transform = 'translateY(0px)';
            reservationPanel.style.position = 'fixed';
        }, 100);

        document.body.style.overflow = 'hidden';
        document.body.style.overscrollBehavior = 'contain';
        document.body.style.position = 'relative';
        document.body.style.paddingRight = '15px';

        const reservationCloseButton = reservationContainer.querySelector('.close');
        reservationCloseButton.addEventListener('click', closereservation1);
        const background = reservationContainer.querySelector('.background');
        background.addEventListener('click', closereservation1);

        
        
        AddTable();
        AddReservationClick();
    });
});



function closereservation1() {
    const reservationPanel = reservationContainer.querySelector('.object[data-type="mobile"]');
    const background = reservationContainer.querySelector('.background');
    background.style.opacity = '0';
    reservationPanel.style.transform = 'translateY(-100%)';

    setTimeout(() => {
        reservationContainer.remove();

        document.body.style.overflow = '';
        document.body.style.overscrollBehavior = '';
        document.body.style.position = '';
        document.body.style.paddingRight = '';
    }, 300);
}



function SetData() {
    var dateContainer = document.getElementById('reservation-date');

    var currentDate = new Date();
    var currentMonth = currentDate.getMonth();
    var months = ['Январь', 'Февраль', 'Март', 'Апрель', 'Май', 'Июнь', 'Июль', 'Август', 'Сентябрь', 'Октябрь', 'Ноябрь', 'Декабрь'];

    var monthSelect = document.createElement('select');
    monthSelect.className = 'input month';
    monthSelect.setAttribute('data-type', 'reservation');
    monthSelect.required = true;
    var monthDefaultOption = document.createElement('option');
    monthDefaultOption.value = '';
    monthDefaultOption.textContent = 'Месяц';
    monthDefaultOption.disabled = true;
    monthDefaultOption.selected = true;
    monthSelect.appendChild(monthDefaultOption);

    for (var month = currentMonth; month < currentMonth + 3; month++) {
        var option = document.createElement('option');
        var monthIndex = month % 12;
        option.value = monthIndex + 1;
        option.textContent = months[monthIndex];
        monthSelect.appendChild(option);
    }
    dateContainer.appendChild(monthSelect);

    var timeSelect = document.getElementById('reservation-time');
    timeSelect.style.display = "none";

    monthSelect.addEventListener('change', function () {
        timeSelect.style.display = "none";

        const tableButton = document.getElementById('reservation-table');
        tableButton.disabled = true;
        tableButton.textContent = '';
        GetCatList(false);

        if (this.value !== '') {
            var existingDaySelect = document.querySelector('.input.day');
            if (existingDaySelect) {
                dateContainer.removeChild(existingDaySelect);
            }

            var daySelect = document.createElement('select');
            daySelect.className = 'input day';
            daySelect.setAttribute('data-type', 'reservation');
            daySelect.required = true;
            var dayDefaultOption = document.createElement('option');
            dayDefaultOption.value = '';
            dayDefaultOption.textContent = 'День';
            dayDefaultOption.disabled = true;
            dayDefaultOption.selected = true;
            daySelect.appendChild(dayDefaultOption);

            var monthSelected = document.querySelector('.input.month');
            var days = monthSelected.value == (currentMonth + 1) ? currentDate.getDate() : 1;

            for (var i = days; i <= 31; i++) {
                var option = document.createElement('option');
                option.value = i;
                option.textContent = i;
                daySelect.appendChild(option);
            }
            dateContainer.appendChild(daySelect);



            daySelect.addEventListener('change', function () {
                if (this.value !== '') {
                    timeSelect.style.display = "inline-block";
                    tableButton.disabled = false;
                    tableButton.textContent = '';
                    GetCatList(true);
                }
                else {
                    timeSelect.style.display = "none";
                    tableButton.disabled = true;
                    tableButton.textContent = '';
                    GetCatList(false);
                }
                SetTime(monthSelected.value == (currentMonth + 1), document.querySelector('.input.day'));
            });
        }
    });
}

function SetTime(isMonth, daySelected) {
    var selectElement = document.getElementById('booking-time');

    var currentDate = new Date();
    var currentHour = currentDate.getHours();

    var startTime = isMonth ? (daySelected.value == currentDate.getDate() ? (currentHour < 10 ? 10 : currentHour + 1) : 10) : 10;
    var endTime = 22;
    var interval = 30;

    if (selectElement.hasChildNodes()) {
        while (selectElement.firstChild) {
            selectElement.removeChild(selectElement.firstChild);
        }
    }

    for (var hour = startTime; hour <= endTime; hour++) {
        for (var minute = 0; minute < 60; minute += interval) {
            var timeString = ('0' + hour).slice(-2) + ':' + ('0' + minute).slice(-2);
            var option = new Option(timeString, timeString);
            selectElement.add(option);
        }
    }

    selectElement.addEventListener('change', function () {
        GetCatList(true);
        const tableButton = document.getElementById('reservation-table');
        tableButton.textContent = '';
    });
}


function GetCatList(view) {
    if (view) {
        const monthSelect = document.querySelector('.input.month');
        const daySelect = document.querySelector('.input.day');


        const selectElement = document.getElementById('booking-time');

        const formData = new FormData();

        formData.append('month', monthSelect.value);
        formData.append('day', daySelect.value);
        formData.append('time', selectElement.value);


        fetch(`/CheckCats`, {
            method: 'PUT',
            body: formData
        })
            .then(response => {
                return response.json();
            })
            .then(data => {
                ViewCatList(view, data);
            });
    }
    else {
        var catsList = document.querySelector('.cats-list');
        catsList.innerHTML = ``;
    }
}


function ViewCatList(view, cats) {

    var catsList = document.querySelector('.cats-list');
    catsList.innerHTML = ``;

    if (view) {
        cats.forEach(cat => {
            catsList.innerHTML += `
        <input class="cats-checkbox" type="checkbox" id="cat-${cat.id}" data-type="table">
        <label class="cats-item" for="cat-${cat.id}">
            <main class="item" data-type="cats">
                <picture class="item-picture" data-type="cats">
                    <img src="data:image.jpg;base64,${cat.photography}" alt="">
                </picture>
                <div class="cats-info">
                    <div class="cats-name">
                       <div class="cat-name">${cat.name}</div>
                       <div class="info-icon" content="<- Порода: ${cat.breed.name} -> \n ${cat.descriptionCharacter}"></div>
                    </div>
                </div>
            </main>
        </label>
        `;
        });

        function limitCheckboxSelection() {
            var checkboxes = document.querySelectorAll('.cats-checkbox:checked');
            var maxAllowed = 2;

            if (checkboxes.length > maxAllowed) {
                this.checked = false;
            }
        }

        var checkboxes = document.querySelectorAll('.cats-checkbox');
        checkboxes.forEach(function (checkbox) {
            checkbox.addEventListener('change', limitCheckboxSelection);
        });
    }
}



function AddReservationClick() {

    const acceptButton = document.getElementById('addReservation');

    acceptButton.addEventListener('click', function () {

        const monthSelect = document.querySelector('.input.month');
        const daySelect = document.querySelector('.input.day');
        const selectElement = document.getElementById('booking-time');
        const tableButton = document.getElementById('reservation-table');

        if (monthSelect !== null
            && daySelect !== null
            && selectElement !== null
            && tableButton !== null
            && monthSelect.value !== ''
            && daySelect.value !== ''
            && selectElement.value !== ''
            && tableButton.textContent !== '') {

            const formData = new FormData();

            formData.append('month', monthSelect.value);
            formData.append('day', daySelect.value);
            formData.append('time', selectElement.value);

            var tables = tableButton.textContent.split(', ').map(Number);
            formData.append('tables', tables.join(','));

            var checkboxes = document.querySelectorAll('.cats-list input[type="checkbox"]:checked');

            var cats = [];

            checkboxes.forEach(function (checkbox) {
                var id = checkbox.getAttribute('id');
                var number = id.split('-')[1];
                cats.push(parseInt(number));
            });

            formData.append('cats', cats.join(','));



            fetch(`/AddReservation`, {
                method: 'POST',
                body: formData
            })
            .then(response => {
                if (response.ok) {
                    return response.text().then(message => {
                        ViewNotify('Успех', message);
                    });
                }
                else
                    return response.text().then(errorMessage => {
                        throw errorMessage;
                    });
            })
            .catch(error => {
                ViewNotify('Ошибка', error);
            });
            closereservation1();
        }
        else
            ViewNotify('Ошибка', 'Не все обязательные поля заполнены');
    });
}
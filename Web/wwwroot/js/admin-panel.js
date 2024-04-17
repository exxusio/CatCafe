const tablesData = [
    {
        name: 'Продукты',
        nameEnglish: 'Products',
        columns: [
            { name: 'id', type: 'integer' },
            { name: 'name', type: 'string' },
            { name: 'typeID', type: 'integer' },
            { name: 'description', type: 'string' },
            { name: 'photography', type: 'bytea' },
            { name: 'price', type: 'decimal(10, 2)' }
        ],
        actions: ['Добавить', 'Посмотреть'],
        actionsEnglish: ['add', 'view']
    },
    {
        name: 'Тип продуктов',
        nameEnglish: 'Types',
        columns: [
            { name: 'id', type: 'integer' },
            { name: 'name', type: 'string' }
        ],
        actions: ['Добавить', 'Посмотреть'],
        actionsEnglish: ['add', 'view']
    },
    {
        name: 'Котики',
        nameEnglish: 'Cats',
        columns: [
            { name: 'id', type: 'integer' },
            { name: 'name', type: 'string' },
            { name: 'breedID', type: 'integer' },
            { name: 'photography', type: 'bytea' },
            { name: 'dateOfBirth', type: 'date' },
            { name: 'descriptionCharacter', type: 'string' }
        ],
        actions: ['Добавить', 'Посмотреть'],
        actionsEnglish: ['add', 'view']
    },
    {
        name: 'Породы',
        nameEnglish: 'Breeds',
        columns: [
            { name: 'id', type: 'integer' },
            { name: 'name', type: 'string' },
            { name: 'description', type: 'string' }
        ],
        actions: ['Добавить', 'Посмотреть'],
        actionsEnglish: ['add', 'view']
    },
    {
        name: 'Мероприятия',
        nameEnglish: 'Events',
        columns: [
            { name: 'id', type: 'integer' },
            { name: 'name', type: 'string' },
            { name: 'description', type: 'string' },
            { name: 'photography', type: 'bytea' },
            { name: 'date', type: 'date' },
            { name: 'time', type: 'time' }
        ],
        actions: ['Добавить', 'Посмотреть'],
        actionsEnglish: ['add', 'view']
    },
    {
        name: 'Работники',
        nameEnglish: 'Employees',
        columns: [
            { name: 'id', type: 'integer' },
            { name: 'name', type: 'string' },
            { name: 'surname', type: 'string' },
            { name: 'positionID', type: 'integer' },
            { name: 'about', type: 'string' },
            { name: 'photography', type: 'bytea' },
            { name: 'salary', type: 'decimal(10, 2)' },
            { name: 'hireDate', type: 'date' }
        ],
        actions: ['Добавить', 'Посмотреть'],
        actionsEnglish: ['add', 'view']
    },
    {
        name: 'Должность',
        nameEnglish: 'Positions',
        columns: [
            { name: 'id', type: 'integer' },
            { name: 'description', type: 'string' }
        ],
        actions: ['Добавить', 'Посмотреть'],
        actionsEnglish: ['add', 'view']
    },
    {
        name: 'Столики',
        nameEnglish: 'Tables',
        columns: [
            { name: 'id', type: 'integer' },
            { name: 'number', type: 'integer' },
            { name: 'capacity', type: 'integer' }
        ],
        actions: ['Добавить', 'Посмотреть'],
        actionsEnglish: ['add', 'view']
    },
    {
        name: 'Посетители',
        nameEnglish: 'Visitors',
        columns: [
            { name: 'id', type: 'integer' },
            { name: 'name', type: 'string' },
            { name: 'surname', type: 'string' },
            { name: 'phoneNumber', type: 'string' },
            { name: 'emailAddress', type: 'string' },
            { name: 'dateOfBirth', type: 'date' }
        ],
        actions: ['Добавить', 'Посмотреть'],
        actionsEnglish: ['add', 'view']
    },
    {
        name: 'Аккаунты',
        nameEnglish: 'Accounts',
        columns: [
            { name: 'id', type: 'integer' },
            { name: 'visitorID', type: 'integer' },
            { name: 'login', type: 'string' },
            { name: 'password', type: 'string' },
            { name: 'registrationDate', type: 'date' }
        ],
        actions: ['Добавить', 'Посмотреть'],
        actionsEnglish: ['add', 'view']
    },
    {
        name: 'Бронирования',
        nameEnglish: 'Reservations',
        columns: [
            { name: 'id', type: 'integer' },
            { name: 'visitorID', type: 'integer' },
            { name: 'date', type: 'date' },
            { name: 'time', type: 'time' }
        ],
        actions: ['Добавить', 'Посмотреть'],
        actionsEnglish: ['add', 'view']
    },
    {
        name: 'Бронирования котиков',
        nameEnglish: 'ReservationCats',
        columns: [
            { name: 'id', type: 'integer' },
            { name: 'reservationID', type: 'integer' },
            { name: 'catID', type: 'integer' }
        ],
        actions: ['Добавить', 'Посмотреть'],
        actionsEnglish: ['add', 'view']
    },
    {
        name: 'Бронирования столиков',
        nameEnglish: 'ReservationTables',
        columns: [
            { name: 'id', type: 'integer' },
            { name: 'reservationID', type: 'integer' },
            { name: 'tableID', type: 'integer' }
        ],
        actions: ['Добавить', 'Посмотреть'],
        actionsEnglish: ['add', 'view']
    },
    {
        name: 'Заказы',
        nameEnglish: 'Orders',
        columns: [
            { name: 'id', type: 'integer' },
            { name: 'visitorID', type: 'integer' },
            { name: 'tableID', type: 'integer' },
            { name: 'date', type: 'date' },
            { name: 'time', type: 'time' }
        ],
        actions: ['Добавить', 'Посмотреть'],
        actionsEnglish: ['add', 'view']
    },
    {
        name: 'Составы заказов',
        nameEnglish: 'Contents',
        columns: [
            { name: 'id', type: 'integer' },
            { name: 'orderID', type: 'integer' },
            { name: 'productID', type: 'integer' },
            { name: 'quantity', type: 'integer' }
        ],
        actions: ['Добавить', 'Посмотреть'],
        actionsEnglish: ['add', 'view']
    },
    {
        name: 'Отзывы',
        nameEnglish: 'Reviews',
        columns: [
            { name: 'id', type: 'integer' },
            { name: 'visitorID', type: 'integer' },
            { name: 'text', type: 'string' },
            { name: 'date', type: 'date' },
            { name: 'time', type: 'time' },
            { name: 'rating', type: 'integer(>=1 and <=5)' }
        ],
        actions: ['Добавить', 'Посмотреть'],
        actionsEnglish: ['add', 'view']
    },
];

const container = document.getElementById('table-list');

tablesData.forEach(tableData => {
    const spanTable = document.createElement('span');

    const tableElement = document.createElement('div');
    tableElement.classList.add('table-element');
    tableElement.innerHTML = `
    <input type="checkbox" id="${tableData.nameEnglish}" class="table-select">
    <label for="${tableData.nameEnglish}" class="table-block">
        <div class="table-name" name="${tableData.nameEnglish}">
            <span>${tableData.name}</span>
        </div>
        <button class="table-button">
            <svg viewBox="0 0 24 24" width="24" height="24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round">
                <path d="M22 12l-10 7-10-7"/>
                <path d="M22 16l-10-7-10 7"/>
            </svg>                                      
        </button>
    </label>
    `;

    const tablePanel = document.createElement('div');
    tablePanel.classList.add('table-panel');
    
    const spanActionList = document.createElement('div');
    spanActionList.classList.add('table-actions-list');
    
    

    tableData.actionsEnglish.forEach((action, index) => {
        const spanAction = document.createElement('span');
        
        const actionElement = document.createElement('div');
        actionElement.classList.add('action-element');
        actionElement.innerHTML = `
        <input type="checkbox" id="${ action + tableData.nameEnglish}" class="action-select">
        <label for="${action + tableData.nameEnglish}" class="action-block">
            <div class="action-name">
                <span>${tableData.actions[index]}</span>
             </div>
            <button class="action-button">
                <svg viewBox="0 0 24 24" width="24" height="24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round">
                    <path d="M22 12l-10 7-10-7"/>
                    <path d="M22 16l-10-7-10 7"/>
                </svg>                                      
            </button>
        </label>
        `;
        
        const actionPanel = document.createElement('div');
        actionPanel.classList.add('action-panel');
        const actionElementList = document.createElement('div');
        actionElementList.classList.add('action-element-list');

        const actionHeader = document.createElement('form');
        if (action === "add")
        {
            actionHeader.setAttribute('action', `/AdminPanel/Add${tableData.nameEnglish}`);
            actionHeader.setAttribute('name', 'add');
            actionHeader.setAttribute('method', 'post');
        }
        else
        {
            actionHeader.setAttribute('action', `/AdminPanel/View${tableData.nameEnglish}`);
            actionHeader.setAttribute('name', 'view');
            actionHeader.setAttribute('method', 'get');
        }
        actionHeader.classList.add('action-header');

        actionHeader.innerHTML = `
        <div class="action-title">
            <div class="action-text">
                <div style="cursor: pointer; margin-left: -10px; padding: 0 10px 0 10px;">Параметры</div>
            </div>
            <div class="action-text-line"></div>
        </div>
        `;

        const actionParameters = document.createElement('div');
        actionParameters.classList.add('action-parameters');
        const actionContainer = document.createElement('div');
        actionContainer.classList.add('action-container');
        const parametersAdmin = document.createElement('table');
        parametersAdmin.classList.add('parameters');
        parametersAdmin.setAttribute('data-type', 'admin');

        parametersAdmin.innerHTML = `
        <thead>
            <tr>
                <th class="parameters-header" data-type="name">Название</th>
                <th class="parameters-header" data-type="description">Описание</th>
            </tr>
        </thead>
        `;

        const parametersBody = document.createElement('tbody');

        const BreakException = {};
        try {
            tableData.columns.forEach(column => {
                if (action === 'add' && column.name === 'id') {
                    return;
                }
                else if (action === 'view' && column.name !== 'id') {
                    throw BreakException;
                }
                const parametersTr = document.createElement('tr');
    
                parametersTr.innerHTML = `
                <td class="parameters-body" data-type="name">
                    <div class="parameters-name">${column.name}</div>
                    <div class="parameters-type">${column.type}</div>
                </td>
                <td class="parameters-body" data-type="description">
                    <input name="${column.name}" id="${action + tableData.nameEnglish + column.name}" type="${column.type === 'bytea' ? 'file' : column.type === 'date' ? 'date' : column.type === 'time' ? 'time' : 'text'}" placeholder="${column.name}" class="input" data-type="admin">
                </td>
                `;
                        
                parametersBody.appendChild(parametersTr);
            });
        } catch (e) {
            if (e !== BreakException) throw e;
        }



        parametersAdmin.appendChild(parametersBody);
        actionContainer.appendChild(parametersAdmin);
        actionParameters.appendChild(actionContainer);
        actionHeader.appendChild(actionParameters);

        actionHeader.innerHTML += `
        <div class="action-footer">
            <button class="action-accept" type="submit">Подтвердить</button>
        </div>
        `;

        actionElementList.appendChild(actionHeader);
        actionPanel.appendChild(actionElementList);
        actionElement.appendChild(actionPanel);
        spanAction.appendChild(actionElement);
        spanActionList.appendChild(spanAction);
    });


    tablePanel.appendChild(spanActionList);
    tableElement.appendChild(tablePanel);
    spanTable.appendChild(tableElement);
    container.appendChild(spanTable);
});



ViewTableData();
AddTableData();
CreateTable();



function ObserverHeaderAdmin() {
    const tableData = document.querySelector('.table-data');

    if (!tableData) {
        return;
    }

    checkScrollbars(tableData);

    const observer = new MutationObserver(mutationsList => {
        mutationsList.forEach(mutation => {
            if (mutation.type === 'childList') {
                checkScrollbars(tableData);
            }
        });
    });

    const config = { childList: true, subtree: true };
    observer.observe(tableData, config);

    function checkScrollbars(element) {
        const hasHorizontalScrollbar = checkScrollBar(element, 'horizontal');
        const hasVerticalScrollbar = checkScrollBar(element, 'vertical');

        const adminTableHeader = document.querySelector('.admin-table-header');
        adminTableHeader.style.marginRight = hasHorizontalScrollbar || hasVerticalScrollbar ? '30px' : '';
    }

    function checkScrollBar(element, direction) {
        const prop = direction === 'vertical' ? 'offsetHeight' : 'offsetWidth';
        const hasScrollbar = element.scrollHeight > element.clientHeight;
        return hasScrollbar;
    }
}



var tableName;

function CreateTable() {
    const elements = document.querySelectorAll('.action-select[id^="view"]');
    elements.forEach(element => {
        const parent = element.closest('.action-element');
        const acceptButton = parent.querySelector('.action-accept');
        parent.querySelector('.action-title').remove();
        parent.querySelector('.action-parameters').remove();


        acceptButton.addEventListener('click', (event) => {
            const adminContainer = document.createElement('div');

            adminContainer.innerHTML = `
        <div class="background" style="opacity: 0;"></div>
        <div class="object" data-type="mobile">
            <div class="frame" data-type="admin" data-equalizer>
                <div class="admin-panel">
                    <button class="close" data-type="admin">
                        <svg width="25" height="25" viewBox="0 0 25 25" fill="none">
                            <path fill-rule="evenodd" clip-rule="evenodd" fill="#fff" d="M9.61 12.199L.54 3.129A1.833 1.833 0 113.13.536l9.07 9.07L21.27.54a1.833 1.833 0 012.592 2.592l-9.068 9.068 9.07 9.07a1.833 1.833 0 01-2.59 2.592l-9.072-9.07-9.073 9.073a1.833 1.833 0 01-2.591-2.592L9.61 12.2z"></path>
                        </svg>
                    </button>
                    <div>
                        <header class="admin-title" data-equalizer-watch>
                            <charttitle :title="title"></charttitle>
                        </header>
                        <div>
                            <charttable :columns="columns" :data="data" :tableName="tableName"></charttable>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        `;

            const adminPanel = document.querySelector('.admin-window');
            adminPanel.appendChild(adminContainer);

            setTimeout(() => {
                const adminPanel = adminContainer.querySelector('.object[data-type="mobile"]');
                background.style.transition = 'opacity 300ms ease-out';
                adminPanel.style.transition = 'transform 300ms ease-out';
                background.style.opacity = '1';
                adminPanel.style.transform = 'translateY(0px)';
                adminPanel.style.position = 'fixed';
            }, 100);

            document.body.style.overflow = 'hidden';
            document.body.style.overscrollBehavior = 'contain';
            document.body.style.position = 'relative';
            document.body.style.paddingRight = '15px';

            const background = adminContainer.querySelector('.background');
            background.addEventListener('click', closereservation);

            function closereservation() {
                const adminPanel = adminContainer.querySelector('.object[data-type="mobile"]');
                const background = adminContainer.querySelector('.background');
                background.style.opacity = '0';
                adminPanel.style.transform = 'translateY(-100%)';
                setTimeout(() => {
                    adminContainer.remove();

                    document.body.style.overflow = '';
                    document.body.style.overscrollBehavior = '';
                    document.body.style.position = '';
                    document.body.style.paddingRight = '';
                }, 300);
            }

            setTimeout(() => {
                ObserverHeaderAdmin();
                EditTableData(tableName);

                const adminCloseButton = adminPanel.querySelector('.close[data-type="admin"]');
                adminCloseButton.addEventListener('click', closereservation);
            }, 400);

            setTimeout(() => {
                ObserverHeaderAdmin();
                const adminCloseButton = adminPanel.querySelector('.close[data-type="admin"]');
                adminCloseButton.addEventListener('click', closereservation);
            }, 600);
        });
    });
}

function ViewTableData() {
    var forms = document.querySelectorAll('form[name="view"]');
    forms.forEach(function (form) {
        form.addEventListener('submit', function (event) {
            event.preventDefault();

            fetch(this.action, {
                method: 'GET'
            })
                .then(response => response.json())
                .then(data => {
                    if (data !== null && data !== undefined && data[0] !== null && data[0] !== undefined) {

                        var firstItem = data[0];

                        var paramNames = Object.keys(firstItem).map(key => {
                            if (typeof firstItem[key] === 'object' && !Array.isArray(firstItem[key])) {
                                return key + 'ID';
                            } else if (Array.isArray(firstItem[key])) {
                                return null;
                            } else {
                                return key;
                            }
                        }).filter(key => key !== null);


                        //const transformedData = data.map(item => {
                        //    const newItem = {};

                        //    Object.keys(item).forEach(key => {
                        //        if (typeof item[key] === 'object' && item[key] !== null && !Array.isArray(item[key])) {
                        //            newItem[key + 'ID'] = item[key].id;
                        //        } else {
                        //            newItem[key] = item[key];
                        //        }
                        //    });

                        //    return newItem;
                        //});

                        var title = event.target.closest('.table-element').querySelector('.table-name span').innerText;
                        tableName = event.target.closest('.table-element').querySelector('.table-name').getAttribute('name');

                        CreateVue(/*transformedData*/transformData(data), paramNames, title, tableName);
                    }
                });
        });
    });
}

function AddTableData() {
    var forms = document.querySelectorAll('form[name="add"]');
    forms.forEach(function (form) {
        form.addEventListener('submit', function (event) {
            event.preventDefault();

            var formData = new FormData(this);

            fetch(this.action, {
                method: 'POST',
                body: formData
            })
                .then(response => {
                    if (!response.ok) {
                        return response.text().then(errorMessage => {
                            throw new Error(errorMessage);
                        });
                    }
                    return response.text();
                })
                .then(message => {
                    var inputs = form.querySelectorAll('input');
                    inputs.forEach(input => {
                        input.value = "";
                    })
                    ViewNotify('Успех', message);
                })
                .catch(error => {
                    ViewNotify('Ошибка', error.message);
                });
        });
    });
}

function EditTableData(tableName) {
    document.querySelectorAll('.edit-mode').forEach(editMode => {
        editMode.addEventListener('click', function (event) {
            event.preventDefault();

            const row = this.closest('.table-row');
            const formData = new FormData();

            const inputs = row.querySelectorAll('input');

            let isAnyInputChanged = false;

            inputs.forEach(input => {
                if (input.name !== 'id' && input.disabled === true) {
                    isAnyInputChanged = true;
                }
            });

            if (isAnyInputChanged) {
                inputs.forEach(input => {
                    formData.append(input.name, input.value);

                    const fileInput = row.querySelector('input[type="file"]');
                    if (fileInput !== null && fileInput.files.length > 0) {
                        const file = fileInput.files[0];
                        formData.append('photography', file);
                        isAnyInputChanged = true;
                    }
                });

                fetch(`/AdminPanel/Edit${tableName}`, {
                    method: 'PUT',
                    body: formData
                })
                    .then(response => {
                        if (!response.ok) {
                            return response.json().then(errorData => {
                                throw new Error(JSON.stringify({ error: errorData, response: response }));
                            });
                        }
                        return response.json();
                    })
                    .catch(error => {
                        const errorData = JSON.parse(error.message);

                        const errorMessage = errorData.error.message;
                        ViewNotify('Ошибка', errorMessage);

                        const otherData = errorData.error.values;

                        return { values: otherData };
                    })
                    .then(data => {
                        //for (const key in data.values.value) {
                        //    const input = row.querySelector(`input[name="${key}"]`);
                        //    if (input) {
                        //        if (input.type === 'file') {
                        //            input.value = '';
                        //            const image = input.closest('.input-container').querySelector('img');
                        //            image.src = `data:image/jpeg;base64,${data.values.value[key]}`;
                        //        } else {
                        //            input.value = data.values.value[key];
                        //        }
                        //    }
                        //}

                        var vueInstance = document.querySelector('.frame[data-type="admin"]').__vue__;
                        vueInstance.data = transformData(data.values.value);

                        if (data.message !== undefined)
                            ViewNotify('Успех', data.message);
                    });
            }
        });
    });
}

function CreateVue(dataTable, paramNames, titleTable, tableName) {
    new Vue({
        el: '.frame[data-type="admin"]',
        data: {
            tableName: tableName,
            title: titleTable,
            columns: paramNames,
            data: dataTable
        }
    });
}

Vue.component('charttitle', {
    props: ['title'],
    template: `
      <div>{{ title }}</div>
    `
});
  
Vue.component('charttable',{
    props: ['columns', 'data', 'tableName'],
    data() {
        return {
            disabledInputs: new Array(this.data.length).fill(true),
            activeEditIndex: null
        };
    },
    methods: {
        deleteEvent(index) {
            const row = document.querySelector(`.table-row[name="${index}"]`);
            const inputs = row.querySelectorAll('input');

            let shouldDelete = false;

            inputs.forEach(input => {
                if (input.name !== 'id' && input.disabled === true) {
                    shouldDelete = true;
                    return;
                } else {
                    shouldDelete = false;
                    return;
                }
            });

            if (shouldDelete) {
                const formData = new FormData();

                inputs.forEach(input => {
                    if (input.name === 'id') {
                        formData.append(input.name, input.value);
                    }
                });
                fetch(`/AdminPanel/Delete${tableName}`, {
                    method: 'DELETE',
                    body: formData
                })
                    .then(response => {
                        if (!response.ok) {
                            return response.text().then(errorMessage => {
                                throw new Error(errorMessage);
                            });
                        }
                        return response.text();
                    })
                    .then(message => {
                        this.data.splice(index, 1);
                        this.disabledInputs.splice(index, 1);
                        if (this.activeEditIndex === index) {
                            this.activeEditIndex = null;
                        }
                        ViewNotify('Успех', message);
                    })
                    .catch(error => {
                        ViewNotify('Ошибка', error.message);
                    });
            }
            else {
                const inputsId = document.querySelectorAll(`form[name="${index}"] input[name="id"]`);

                inputsId.forEach(input => {
                    if (input.name === "id") {
                        const formData = new FormData();
                        formData.append(input.name, input.value);

                        fetch(`/AdminPanel/View${tableName}ById`, {
                            method: 'PUT',
                            body: formData
                        })
                            .then(response => {
                                if (!response.ok) {
                                    return response.text().then(errorMessage => {
                                        throw new Error(errorMessage);
                                    });
                                }
                                return response.json();
                            })
                            .then(data => {
                                //for (const key in data.values.value) {
                                //    const input = document.querySelector(`form[name="${index}"] input[name="${key}"]`);
                                //    if (input) {
                                //        if (input.type === 'file') {
                                //            input.value = '';
                                //            const image = input.closest('.input-container').querySelector('img');
                                //            image.src = `data:image/jpeg;base64,${data.values.value[key]}`;
                                //        } else {
                                //            input.value = data.values.value[key];
                                //        }
                                //    }
                                //}
                                var vueInstance = document.querySelector('.frame[data-type="admin"]').__vue__;
                                vueInstance.data = transformData(data.values.value);
                            })
                            .catch(error => {
                                ViewNotify('Ошибка', error.message);
                            });
                    }
                });

                this.toggleDisabled(index);
            }
        },
        toggleDisabled(index) {
            if (this.activeEditIndex !== null && this.activeEditIndex !== index) {
                return;
            }
            this.$set(this.disabledInputs, index, !this.disabledInputs[index]);
            this.activeEditIndex = this.activeEditIndex === null ? index : null;
        },
        isType(value) {
            if (typeof value === 'string') {
                if (value.match(/^\d{2}:\d{2}$/) || value.match(/^\d{2}:\d{2}:\d{2}$/)) {
                    return 'time';
                } else if (value.match(/^\d{4}-\d{2}-\d{2}$/)) {
                    return 'date';
                } else {
                    var base64Regex = /^([0-9a-zA-Z+/]{4})*(([0-9a-zA-Z+/]{2}==)|([0-9a-zA-Z+/]{3}=))?$/;
                    if (base64Regex.test(value) && value.length > 100) {
                        return 'image';
                    }
                }
            }
            return 'text';
        },
        isFirstInRow(key) {
            return key === 'id';
        },
        async convertUrlToBase64(url) {
            const response = await fetch(url);
            const blob = await response.blob();
            return new Promise((resolve, reject) => {
                const reader = new FileReader();
                reader.onloadend = () => resolve(reader.result);
                reader.onerror = reject;
                reader.readAsDataURL(blob);
            });
        }
    },
    template: `
     <div class="admin-table">
        <div style="border-bottom: 2px solid rgb(var(--primary-color-hover), 0.3);">
            <div class="admin-table-header">
                <div v-for="column in columns">{{ column }}</div>
                <div>
                    <i class="fa fa-trash" aria-hidden="true"></i>
                </div>
            </div>
        </div>
        <div class="table-data">
            <form v-for="(row, index) in data" class="table-row" :name="index">
                <div v-for="(value, key) in row" :key="key" class="input-container">
                    <template v-if="isType(value) === 'time'">
                        <input type="time" :name="key" v-model="row[key]" :disabled="disabledInputs[index]" class="input-admin" />
                    </template>
                    <template v-else-if="isType(value) === 'date'">
                        <input type="date" :name="key" v-model="row[key]" :disabled="disabledInputs[index]" class="input-admin" />
                    </template>
                    <template v-else-if="isType(value) === 'image'">
                        <input type="file" :name="key" class="input-admin" :disabled="disabledInputs[index]"/>
                        <img :src="'data:image/jpeg;base64,' + value" alt="Image" />
                    </template>
                    <template v-else>
                        <input type="text" :name="key" v-model="row[key]" :value="row[key]" :disabled="disabledInputs[index] || isFirstInRow(key)" class="input-admin" />
                    </template>
                </div>
                <div class="edit-block">
                    <span class="edit-mode" @click="toggleDisabled(index)">
                        <i class="fa fa-pencil-square-o" aria-hidden="true"></i>
                    </span>
                    <button type="button" @click="deleteEvent(index)">
                        <i class="fa fa-times" aria-hidden="true"></i>
                    </button>
                </div>
            </form>
        </div>
    </div>
    `
});



function transformData(data) {
    return data.map(item => {
        const newItem = {};

        Object.keys(item).forEach(key => {
            if (typeof item[key] === 'object' && item[key] !== null && !Array.isArray(item[key])) {
                newItem[key + 'ID'] = item[key].id;
            } else if (Array.isArray(item[key])) {
                return null;
            } else {
                newItem[key] = item[key];
            }
        });

        return newItem;
    }).filter(key => key !== null);
}

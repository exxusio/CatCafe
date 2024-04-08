const tablesData = [
    { 
        name: 'Продукты', 
        nameEnglish: 'Cafe.Products',
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
        nameEnglish: 'ProductsType',
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
            { name: 'character', type: 'string' }
        ], 
        actions: ['Добавить', 'Посмотреть'],
        actionsEnglish: ['add', 'view']
    },
    { 
        name: 'Породы', 
        nameEnglish: 'Breed',
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
            { name: 'price', type: 'decimal(10, 2)' },
            { name: 'date', type: 'date' },
            { name: 'time', type: 'time' }
        ], 
        actions: ['Добавить', 'Посмотреть'],
        actionsEnglish: ['add', 'view']
    },
    { 
        name: 'Работники', 
        nameEnglish: 'Workers',
        columns: [
            { name: 'id', type: 'integer' },
            { name: 'name', type: 'string' },
            { name: 'surname', type: 'string' },
            { name: 'positionID', type: 'integer' },
            { name: 'about', type: 'string' },
            { name: 'photography', type: 'bytea' },
            { name: 'slary', type: 'decimal(10, 2)' },
            { name: 'hireDate', type: 'date' }
        ], 
        actions: ['Добавить', 'Посмотреть'],
        actionsEnglish: ['add', 'view']
    },
    { 
        name: 'Должность', 
        nameEnglish: 'Position',
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
            { name: 'tableNumer', type: 'integer' },
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
            { name: 'phone', type: 'string' },
            { name: 'email', type: 'string' },
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
            { name: 'registerDate', type: 'date' }
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
            { name: 'name', type: 'string' },
            { name: 'date', type: 'date' },
            { name: 'time', type: 'time' }
        ], 
        actions: ['Добавить', 'Посмотреть'],
        actionsEnglish: ['add', 'view']
    },
    { 
        name: 'Бронирования котиков', 
        nameEnglish: 'ReservationsCats',
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
        nameEnglish: 'ReservationsTables',
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
        <div class="table-name">
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
        const actionHeader = document.createElement('div');
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
                else if (/*(action === 'delete' || */action === 'view'/*)*/ && column.name !== 'id') {
                    throw BreakException;
                }
                const parametersTr = document.createElement('tr');
    
                parametersTr.innerHTML = `
                <td class="parameters-body" data-type="name">
                    <div class="parameters-name">${column.name}</div>
                    <div class="parameters-type">${column.type}</div>
                </td>
                <td class="parameters-body" data-type="description">
                    <input id="${action + tableData.nameEnglish + column.name}" type="${column.type === 'bytea' ? 'file' : column.type === 'date' ? 'date' : column.type === 'time' ? 'time' : 'text'}" placeholder="${column.name}" class="input" data-type="admin">
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
            <button class="action-accept">Подтвердить</button>
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
                            <charttable :columns="columns" :data="data"></charttable>
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

        CreateTableData();
        document.querySelector('.frame[data-type="admin"]').__vue__.title = event.target.closest('.table-element').querySelector('.table-name span').innerText;
        ObserverHeaderAdmin();

        const adminCloseButton = adminContainer.querySelector('.close');
        adminCloseButton.addEventListener('click', closereservation);
    });
});



function ObserverHeaderAdmin() {
    const tableData = document.querySelector('.table-data');

    if(tableData === null) {
        return;
    }

    const observer = new MutationObserver((mutationsList, observer) => {
        checkScrollbars(tableData);
    });
    const config = { childList: true, subtree: true };

    observer.observe(tableData, config);

    function checkScrollbars(element) {
        const hasHorizontalScrollbar = checkScrollBar(element, 'horizontal');
        const hasVerticalScrollbar = checkScrollBar(element, 'vertical');

        if (hasHorizontalScrollbar || hasVerticalScrollbar) {
            const adminTableHeader = document.querySelector('.admin-table-header');
            adminTableHeader.style.marginRight = '30px';
        } else {
            const adminTableHeader = document.querySelector('.admin-table-header');
            adminTableHeader.style.marginRight = '';
        }
    }

    function checkScrollBar(element, direction) {
        direction = (direction === 'vertical') ? 'scrollTop' : 'scrollLeft';

        let hasScrollbar = !!element[direction];

        if (!hasScrollbar) {
            element[direction] = 1;
            hasScrollbar = !!element[direction];
            element[direction] = 0;
        }

        return hasScrollbar;
    }
}



function CreateTableData() {
    new Vue({
        el: '.frame[data-type="admin"]',
        data: {
            tableName: 'Cafe.Visitors',
            title: '',
            columns: [],
            data: []
        },
        created() {
            this.getTableData();
            this.getTableColumns();
        },
        methods: {
          async getTableData() {
            try {
                const response = await fetch(`../json-test/${this.tableName}_data.json`);
                const data = await response.json();
                this.data = data;
            } catch (error) {
                console.error('Error fetching data', error);
            }
          },
          async getTableColumns() {
            try {
                const response = await fetch(`../json-test/${this.tableName}_columns.json`);
                const columns = await response.json();
                this.columns = columns;
            } catch (error) {
                console.error('Error fetching columns', error);
            }
          }
        }
      });
}



Vue.component('charttitle',{
    props: ['title'],
    template: `
      <div>{{ title }}</div>
    `
  })
  
  Vue.component('charttable',{
    props: ['columns', 'data'],
    data() {
        return {
            disabledInputs: new Array(this.data.length).fill(true),
            activeEditIndex: null
        };
    },
    methods: {
        deleteEvent(index) {
            this.data.splice(index, 1);
            this.disabledInputs.splice(index, 1);
            if (this.activeEditIndex === index) {
                this.activeEditIndex = null;
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
                if (value.match(/^\d{2}:\d{2}$/)) {
                    return 'time';
                } else if (value.match(/^\d{4}-\d{2}-\d{2}$/)) {
                    return 'date';
                } else if (value.match(/\.(jpeg|jpg|gif|png)$/) || /^\\x[0-9a-fA-F]*$/.test(value)) {
                    return 'image';
                }
            }
            return 'text';
        },
        isFirstInRow(rowIndex, elementIndex) {
            console.log(elementIndex);
            return elementIndex === 0;
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
            <div v-for="(row, index) in data" class="table-row">
                <div v-for="(value, key) in Object.values(row)">
                    <template v-if="isType(value) === 'time'">
                        <input type="time" v-model="value" :disabled="!disabledInputs[index]" class="input-admin" />
                    </template>
                    <template v-else-if="isType(value) === 'date'">
                        <input type="date" v-model="value" :disabled="!disabledInputs[index]" class="input-admin" />
                    </template>
                    <template v-else-if="isType(value) === 'image'">
                        <input type="file" class="input-admin" :disabled="!disabledInputs[index]"/>
                        <img :src="value" alt="Image" />
                    </template>
                    <template v-else>
                        <input type="text" v-model="value" :disabled="!disabledInputs[index] || isFirstInRow(index, key)" class="input-admin" />
                    </template>
                </div>
                <div class="edit-block">
                    <span class="edit-mode" @click="toggleDisabled(index)">
                        <i class="fa fa-pencil-square-o" aria-hidden="true"></i>
                    </span>
                    <button @click="deleteEvent(index)">
                        <i class="fa fa-times" aria-hidden="true"></i>
                    </button>
                </div>
            </div>
        </div>
      </div>
    `
});





















// const adminPanel = document.querySelector('.panel[data-type="admin"]');

// const tableSelect = adminPanel.querySelectorAll('.table-select');

// tableSelect.forEach((checkbox, index) => {
//     const id = `admin-table-${index + 1}`;
//     checkbox.id = id;
//     const label = checkbox.nextElementSibling;
//     label.setAttribute('for', id);
// });

// const actionSelect = adminPanel.querySelectorAll('.action-select');

// actionSelect.forEach((checkbox, index) => {
//     const id = `table-action-${index + 1}`;
//     checkbox.id = id;
//     const label = checkbox.nextElementSibling;
//     label.setAttribute('for', id);
// });




{/* <span>
                        <div class="table-element">
                            <input type="checkbox" class="table-select">
                            <label class="table-block">
                                <div class="table-name">
                                    <span>Продукты</span>
                                </div>
                                <button class="table-button">
                                    <svg viewBox="0 0 24 24" width="24" height="24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round">
                                        <path d="M22 12l-10 7-10-7"/>
                                        <path d="M22 16l-10-7-10 7"/>
                                      </svg>                                      
                                </button>
                            </label>

                            <div class="table-panel">
                                <div class="table-actions-list">
                                    <span>
                                        <div class="action-element">
                                            <input type="checkbox" class="action-select">
                                            <label class="action-block">
                                                <div class="action-name">
                                                    <span>Добавить</span>
                                                 </div>
                                                <button class="action-button">
                                                    <svg viewBox="0 0 24 24" width="24" height="24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round">
                                                        <path d="M22 12l-10 7-10-7"/>
                                                        <path d="M22 16l-10-7-10 7"/>
                                                    </svg>                                      
                                                </button>
                                            </label>
    
                                            <div class="action-panel">
                                                <div class="action-element-list">
                                                    <div class="action-header">
                                                        <div class="action-title">
                                                            <div class="action-text">
                                                                <div style="cursor: pointer; margin-left: -10px; padding: 0 10px 0 10px;">Параметры</div>
                                                            </div>
                                                            <div class="action-text-line"></div>
                                                        </div>
                                                        <div class="action-parameters">
                                                            <div class="action-container">
                                                                <table class="parameters" data-type="admin">
                                                                    <thead>
                                                                        <tr>
                                                                            <th class="parameters-header" data-type="name">Название</th>
                                                                            <th class="parameters-header" data-type="description">Описание</th>
                                                                        </tr>
                                                                    </thead>
                                                                    <tbody>
                                                                        <tr>
                                                                            <td class="parameters-body" data-type="name">
                                                                                <div class="parameters-name">name</div>
                                                                                <div class="parameters-type">string</div>
                                                                            </td>
                                                                            <td class="parameters-body" data-type="description">
                                                                                <input type="text" placeholder="name" class="input" data-type="admin">
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="parameters-body" data-type="name">
                                                                                <div class="parameters-name">typeID</div>
                                                                                <div class="parameters-type">integer</div>
                                                                            </td>
                                                                            <td class="parameters-body" data-type="description">
                                                                                <input type="text" placeholder="typeID" class="input" data-type="admin">
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="parameters-body" data-type="name">
                                                                                <div class="parameters-name">description</div>
                                                                                <div class="parameters-type">string</div>
                                                                            </td>
                                                                            <td class="parameters-body" data-type="description">
                                                                                <input type="text" placeholder="description" class="input" data-type="admin">
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="parameters-body" data-type="name">
                                                                                <div class="parameters-name">photography</div>
                                                                                <div class="parameters-type">bytea</div>
                                                                            </td>
                                                                            <td class="parameters-body" data-type="description">
                                                                                <input type="file" accept="image/*" class="input" data-type="admin">
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="parameters-body" data-type="name">
                                                                                <div class="parameters-name">price</div>
                                                                                <div class="parameters-type">decimal(10, 2)</div>
                                                                            </td>
                                                                            <td class="parameters-body" data-type="description">
                                                                                <input type="text" placeholder="price" class="input" data-type="admin">
                                                                            </td>
                                                                        </tr>
                                                                    </tbody>
                                                                </table>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="action-footer">
                                                        <button class="action-accept">Подтвердить</button>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </span>
                                    <span>
                                        <div class="action-element">
                                            <input type="checkbox" class="action-select">
                                            <label class="action-block">
                                                <div class="action-name">
                                                    <span>Редактировать</span>
                                                 </div>
                                                <button class="action-button">
                                                    <svg viewBox="0 0 24 24" width="24" height="24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round">
                                                        <path d="M22 12l-10 7-10-7"/>
                                                        <path d="M22 16l-10-7-10 7"/>
                                                    </svg>                                      
                                                </button>
                                            </label>
    
                                            <div class="action-panel">
                                                <div class="action-element-list">
                                                    <div class="action-header">
                                                        <div class="action-title">
                                                            <div class="action-text">
                                                                <div style="cursor: pointer; margin-left: -10px; padding: 0 10px 0 10px;">Параметры</div>
                                                            </div>
                                                            <div class="action-text-line"></div>
                                                        </div>
                                                        <div class="action-parameters">
                                                            <div class="action-container">
                                                                <table class="parameters" data-type="admin">
                                                                    <thead>
                                                                        <tr>
                                                                            <th class="parameters-header" data-type="name">Название</th>
                                                                            <th class="parameters-header" data-type="description">Описание</th>
                                                                        </tr>
                                                                    </thead>
                                                                    <tbody>
                                                                        <tr>
                                                                            <td class="parameters-body" data-type="name">
                                                                                <div class="parameters-name">id</div>
                                                                                <div class="parameters-type">integer</div>
                                                                            </td>
                                                                            <td class="parameters-body" data-type="description">
                                                                                <input type="text" placeholder="id" class="input" data-type="admin">
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="parameters-body" data-type="name">
                                                                                <div class="parameters-name">name</div>
                                                                                <div class="parameters-type">string</div>
                                                                            </td>
                                                                            <td class="parameters-body" data-type="description">
                                                                                <input type="text" placeholder="name" class="input" data-type="admin">
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="parameters-body" data-type="name">
                                                                                <div class="parameters-name">typeID</div>
                                                                                <div class="parameters-type">integer</div>
                                                                            </td>
                                                                            <td class="parameters-body" data-type="description">
                                                                                <input type="text" placeholder="typeID" class="input" data-type="admin">
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="parameters-body" data-type="name">
                                                                                <div class="parameters-name">description</div>
                                                                                <div class="parameters-type">string</div>
                                                                            </td>
                                                                            <td class="parameters-body" data-type="description">
                                                                                <input type="text" placeholder="description" class="input" data-type="admin">
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="parameters-body" data-type="name">
                                                                                <div class="parameters-name">photography</div>
                                                                                <div class="parameters-type">bytea</div>
                                                                            </td>
                                                                            <td class="parameters-body" data-type="description">
                                                                                <input type="file" accept="image/*" class="input" data-type="admin">
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="parameters-body" data-type="name">
                                                                                <div class="parameters-name">price</div>
                                                                                <div class="parameters-type">decimal(10, 2)</div>
                                                                            </td>
                                                                            <td class="parameters-body" data-type="description">
                                                                                <input type="text" placeholder="price" class="input" data-type="admin">
                                                                            </td>
                                                                        </tr>
                                                                    </tbody>
                                                                </table>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="action-footer">
                                                        <button class="action-accept">Подтвердить</button>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </span>
                                    <span>
                                        <div class="action-element">
                                            <input type="checkbox" class="action-select">
                                            <label class="action-block">
                                                <div class="action-name">
                                                    <span>Удалить</span>
                                                 </div>
                                                <button class="action-button">
                                                    <svg viewBox="0 0 24 24" width="24" height="24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round">
                                                        <path d="M22 12l-10 7-10-7"/>
                                                        <path d="M22 16l-10-7-10 7"/>
                                                    </svg>                                      
                                                </button>
                                            </label>
    
                                            <div class="action-panel">
                                                <div class="action-element-list">
                                                    <div class="action-header">
                                                        <div class="action-title">
                                                            <div class="action-text">
                                                                <div style="cursor: pointer; margin-left: -10px; padding: 0 10px 0 10px;">Параметры</div>
                                                            </div>
                                                            <div class="action-text-line"></div>
                                                        </div>
                                                        <div class="action-parameters">
                                                            <div class="action-container">
                                                                <table class="parameters" data-type="admin">
                                                                    <thead>
                                                                        <tr>
                                                                            <th class="parameters-header" data-type="name">Название</th>
                                                                            <th class="parameters-header" data-type="description">Описание</th>
                                                                        </tr>
                                                                    </thead>
                                                                    <tbody>
                                                                        <tr>
                                                                            <td class="parameters-body" data-type="name">
                                                                                <div class="parameters-name">id</div>
                                                                                <div class="parameters-type">integer</div>
                                                                            </td>
                                                                            <td class="parameters-body" data-type="description">
                                                                                <input type="text" placeholder="id" class="input" data-type="admin">
                                                                            </td>
                                                                        </tr>
                                                                    </tbody>
                                                                </table>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="action-footer">
                                                        <button class="action-accept">Подтвердить</button>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </span>
                                    <span>
                                        <div class="action-element">
                                            <input type="checkbox" class="action-select">
                                            <label class="action-block">
                                                <div class="action-name">
                                                    <span>Посмотреть</span>
                                                 </div>
                                                <button class="action-button">
                                                    <svg viewBox="0 0 24 24" width="24" height="24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round">
                                                        <path d="M22 12l-10 7-10-7"/>
                                                        <path d="M22 16l-10-7-10 7"/>
                                                    </svg>                                      
                                                </button>
                                            </label>
    
                                            <div class="action-panel">
                                                <div class="action-element-list">
                                                    <div class="action-header">
                                                        <div class="action-title">
                                                            <div class="action-text">
                                                                <div style="cursor: pointer; margin-left: -10px; padding: 0 10px 0 10px;">Параметры</div>
                                                            </div>
                                                            <div class="action-text-line"></div>
                                                        </div>
                                                        <div class="action-parameters">
                                                            <div class="action-container">
                                                                <table class="parameters" data-type="admin">
                                                                    <thead>
                                                                        <tr>
                                                                            <th class="parameters-header" data-type="name">Название</th>
                                                                            <th class="parameters-header" data-type="description">Описание</th>
                                                                        </tr>
                                                                    </thead>
                                                                    <tbody>
                                                                        <tr>
                                                                            <td class="parameters-body" data-type="name">
                                                                                <div class="parameters-name">id</div>
                                                                                <div class="parameters-type">integer</div>
                                                                            </td>
                                                                            <td class="parameters-body" data-type="description">
                                                                                <input type="text" placeholder="id" class="input" data-type="admin">
                                                                            </td>
                                                                        </tr>
                                                                    </tbody>
                                                                </table>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="action-footer">
                                                        <button class="action-accept">Подтвердить</button>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </span>
                                </div>
                            </div>
                        </div>
    </span> */}
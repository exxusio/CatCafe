document.addEventListener('DOMContentLoaded', function() {
    const reviewsButton = document.getElementById('buttonHistory');
    const reviewsPanel = document.querySelector('.history-window');

    reviewsButton.addEventListener('click', function() {
        const reviewsContainer = document.createElement('div');

        reviewsContainer.innerHTML = `
        <div class="background" style="opacity: 0;"></div>
<div class="object" data-type="mobile">
    <div class="frame">
        <div class="window" data-type="history">
            <button class="close" data-type="history">
                <svg width="25" height="25" viewBox="0 0 25 25" fill="none">
                    <path fill-rule="evenodd" clip-rule="evenodd" fill="#fff" d="M9.61 12.199L.54 3.129A1.833 1.833 0 113.13.536l9.07 9.07L21.27.54a1.833 1.833 0 012.592 2.592l-9.068 9.068 9.07 9.07a1.833 1.833 0 01-2.59 2.592l-9.072-9.07-9.073 9.073a1.833 1.833 0 01-2.591-2.592L9.61 12.2z"></path>
                </svg>
            </button>
            <div class="info">
                <div class="title">История заказов</div>
            </div>
            <div>
                <div class="form">
                    <div class="container">
                        <div class="history-list">
                        </div>
                    </div>
                </div>

            </div>
        </div>
    </div>
</div>
        `;

        reviewsPanel.appendChild(reviewsContainer);



        fetch(`/VisitorOrders`, {
            method: 'GET'
        })
            .then(response => response.json())
            .then(data => {
                ViewVisitorOrders(data);
            });


        setTimeout(() => {
            const reviewsPanel = reviewsContainer.querySelector('.object[data-type="mobile"]');
            background.style.transition = 'opacity 300ms ease-out';
            reviewsPanel.style.transition = 'transform 300ms ease-out';
            background.style.opacity = '1';
            reviewsPanel.style.transform = 'translateY(0px)';
        }, 100);

        document.body.style.overflow = 'hidden';
        document.body.style.overscrollBehavior = 'contain';
        document.body.style.position = 'relative';
        document.body.style.paddingRight = '15px';
        
        const reviewsCloseButton = reviewsContainer.querySelector('.close');
        reviewsCloseButton.addEventListener('click', closereviews);
        const background = reviewsContainer.querySelector('.background');
        background.addEventListener('click', closereviews);

        function closereviews() {
            const reviewsPanel = reviewsContainer.querySelector('.object[data-type="mobile"]');
            const background = reviewsContainer.querySelector('.background');
            background.style.opacity = '0';
            reviewsPanel.style.transform = 'translateY(-100%)';
        
            setTimeout(() => {
                reviewsContainer.remove();

                document.body.style.overflow = '';
                document.body.style.overscrollBehavior = '';
                document.body.style.position = '';
                document.body.style.paddingRight = '';
            }, 300);
        }
    });
});




function ViewVisitorOrders(orders) {
    const historyList = document.querySelector('.history-list');

    if (!historyList) return;

    historyList.innerHTML = '';

    orders.forEach(order => {
        const historyItem = document.createElement('article');
        historyItem.className = 'history-item';


        const main = document.createElement('main');
        main.className = 'item';
        main.setAttribute('data-type', 'history');


        const historyItemBlock1 = document.createElement('div');
        historyItemBlock1.className = 'history-item-block';
        const numberOrder = document.createElement('span');
        numberOrder.className = 'label';
        numberOrder.textContent = `№${order.id}`;
        const historyDate = document.createElement('div');
        historyDate.className = 'history-text';

        const formatDate = (dateString) => {
            const date = new Date(dateString);
            const options = { year: 'numeric', month: 'long', day: 'numeric', hour: '2-digit', minute: '2-digit' };
            return date.toLocaleDateString('ru-RU', options);
        };

        historyDate.textContent = formatDate(`${order.date}T${order.time}`);


        historyItemBlock1.appendChild(numberOrder);
        historyItemBlock1.appendChild(historyDate);



        const historyItemBlock2 = document.createElement('div');
        historyItemBlock2.className = 'history-item-block';
        historyItemBlock2.innerHTML = `
        <span class="label">Состав</span>
            <div class="history-container">
                <div class="history-list-items">
                </div>
            </div>
        `;

        const historyListItems = historyItemBlock2.querySelector('.history-list-items');
        order.contents.forEach(content => {
            for (var i = 0; i < content.quantity; i++) {
                const historyListItem = document.createElement('article');
                historyListItem.className = 'history-list-item';


                const itemPicture = document.createElement('div');
                itemPicture.className = 'item-picture';
                itemPicture.setAttribute('data-type', 'history');


                const img = document.createElement('img');
                img.src = 'data:image.jpg;base64,' + content.product.photography;
                img.alt = '';


                const itemInfo = document.createElement('span');
                itemInfo.className = 'history-item-info';
                itemInfo.textContent = `${content.product.name}`;

                itemPicture.appendChild(img);
                historyListItem.appendChild(itemPicture);
                historyListItem.appendChild(itemInfo);
                historyListItems.appendChild(historyListItem);
            }
        });



        const historyItemBlock3 = document.createElement('div');
        historyItemBlock3.className = 'history-item-block';
        const summ = document.createElement('span');
        summ.className = 'label';
        summ.textContent = `Сумма`;
        const summNumber = document.createElement('div');
        summNumber.className = 'history-text';
        summNumber.textContent = `${sumOrder(order)} руб.`;

        historyItemBlock3.appendChild(summ);
        historyItemBlock3.appendChild(summNumber);



        const footer = document.createElement('footer');
        footer.className = 'buttons';
        footer.innerHTML = `
        <button class="button" type="button" data-type="primary" data-size="medium">Повторить заказ</button>
        `;


        const repeatOrder = footer.querySelector('.button[data-size="medium"]');

        repeatOrder.addEventListener('click', () => {

            var productIDs = [];
            order.contents.forEach(content => {
                for (var i = 0; i < content.quantity; i++) {
                    productIDs.push(content.product.id);
                }
            });

            const formData = new FormData();

            productIDs.forEach(id => {
                formData.append('productIDs[]', id);
            });

            fetch(`/RepeatOrderToBasket`, {
                method: 'PUT',
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
        });




        main.appendChild(historyItemBlock1);
        main.appendChild(historyItemBlock2);
        main.appendChild(historyItemBlock3);
        main.appendChild(footer);
        historyItem.appendChild(main);
        historyList.appendChild(historyItem);
    });
}

function sumOrder(order) {
    let price = 0;

    order.contents.forEach(content => {
        price += content.product.price;
    });

    return price;
}
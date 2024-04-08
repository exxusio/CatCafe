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
                                                
                                        <article class="history-item">
                                            <main class="item" data-type="history">
                                                <div class="history-item-block">
                                                    <span class="label">№50</span>
                                                    <div class="history-text">20 марта 2024г. в 14:35</div>
                                                </div>
                                                <div class="history-item-block">
                                                    <span class="label">Состав</span>




                                                    <div class="history-container">
                                                        <div class="history-list-items">
                                                            
                                                            <article class="history-list-item">
                                                                <div class="item-picture" data-type="history">
                                                                    <img src="./content/image/pepperoni.png" alt="">
                                                                </div>
                                                                <span class="history-item-info">Пепперони</span>
                                                            </article>
                                                            <article class="history-list-item">
                                                                <div class="item-picture" data-type="history">
                                                                    <img src="./content/image/pepperoni.png" alt="">
                                                                </div>
                                                                <span class="history-item-info">Пепперони</span>
                                                            </article>
                                                            <article class="history-list-item">
                                                                <div class="item-picture" data-type="history">
                                                                    <img src="./content/image/pepperoni.png" alt="">
                                                                </div>
                                                                <span class="history-item-info">Пепперони</span>
                                                            </article>
                                                            <article class="history-list-item">
                                                                <div class="item-picture" data-type="history">
                                                                    <img src="./content/image/pepperoni.png" alt="">
                                                                </div>
                                                                <span class="history-item-info">Пепперони</span>
                                                            </article>
                                                            <article class="history-list-item">
                                                                <div class="item-picture" data-type="history">
                                                                    <img src="./content/image/pepperoni.png" alt="">
                                                                </div>
                                                                <span class="history-item-info">Пепперони</span>
                                                            </article>
                                                            <article class="history-list-item">
                                                                <div class="item-picture" data-type="history">
                                                                    <img src="./content/image/pepperoni.png" alt="">
                                                                </div>
                                                                <span class="history-item-info">Пепперони</span>
                                                            </article>
                                                            <article class="history-list-item">
                                                                <div class="item-picture" data-type="history">
                                                                    <img src="./content/image/pepperoni.png" alt="">
                                                                </div>
                                                                <span class="history-item-info">Пепперони</span>
                                                            </article>
                                                            <article class="history-list-item">
                                                                <div class="item-picture" data-type="history">
                                                                    <img src="./content/image/pepperoni.png" alt="">
                                                                </div>
                                                                <span class="history-item-info">Пепперони</span>
                                                            </article>
                                        
                                                        </div>
                                                    </div>




                                                </div>
                                                <div class="history-item-block">
                                                    <span class="label">Сумма</span>
                                                    <div class="history-text">28,08 руб.</div>
                                                </div>
                                                <footer class="buttons">
                                                    <button class="button" type="button" data-type="primary" data-size="medium">Повторить заказ</button>
                                                </footer>
                                            </main>
                                        </article>
                            
                                    </div>
                                </div>
                            </div>

                        </div>
                    </div>
                </div>
            </div>
        `;

        reviewsPanel.appendChild(reviewsContainer);

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



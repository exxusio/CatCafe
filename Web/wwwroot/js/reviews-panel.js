document.addEventListener('DOMContentLoaded', function() {
    const reviewsButton = document.querySelector('.button[data-types="reviews"]');
    const reviewsPanel = document.querySelector('.reviews-window');

    reviewsButton.addEventListener('click', function() {
        const reviewsContainer = document.createElement('div');

        reviewsContainer.innerHTML = `
        <div class="background" style="opacity: 0;"></div>
        <div class="object" data-type="mobile">
            <div class="frame">
                <div class="window" data-type="reviews">
                    <button class="close" data-type="reviews">
                        <svg width="25" height="25" viewBox="0 0 25 25" fill="none">
                            <path fill-rule="evenodd" clip-rule="evenodd" fill="#fff" d="M9.61 12.199L.54 3.129A1.833 1.833 0 113.13.536l9.07 9.07L21.27.54a1.833 1.833 0 012.592 2.592l-9.068 9.068 9.07 9.07a1.833 1.833 0 01-2.59 2.592l-9.072-9.07-9.073 9.073a1.833 1.833 0 01-2.591-2.592L9.61 12.2z"></path>
                        </svg>
                    </button>
                    <div class="info">
                        <div class="title">Оставьте свой отзыв!</div>
                    </div>
                    <div>
                        <div class="form">
                            <label for="" class="container">
                                    <div class="container">
                                        <textarea type="text" class="input" data-type="reviews" placeholder="Text" required></textarea>
                                    </div>
                            </label>
                        </div>
                    </div>
                    <div class="rating" data-type="reviews">
                        <input type="radio" name="rating" id="rating-5">
                        <label for="rating-5"></label>
                        <input type="radio" name="rating" id="rating-4">
                        <label for="rating-4"></label>
                        <input type="radio" name="rating" id="rating-3">
                        <label for="rating-3"></label>
                        <input type="radio" name="rating" id="rating-2">
                        <label for="rating-2"></label>
                        <input type="radio" name="rating" id="rating-1">
                        <label for="rating-1"></label>
                    </div>
                    <div class="buttons">
                        <button class="button" type="button" data-type="primary" data-size="medium">Подтвердить</button>
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



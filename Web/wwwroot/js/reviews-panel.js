let reviewsContainer;
document.addEventListener('DOMContentLoaded', function () {
    const reviewsButton = document.querySelector('.button[data-types="reviews"]');
    const reviewsPanel = document.querySelector('.reviews-window');

    reviewsButton.addEventListener('click', function() {
        /*const */reviewsContainer = document.createElement('div');

        reviewsContainer.innerHTML = `
        <div class="background" style="opacity: 0;"></div>
        <div class="object" data-type="mobile">
            <div class="frame">
                <form class="window" data-type="reviews">
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
                                        <textarea name="text" type="text" class="input" data-type="reviews" placeholder="Text" required></textarea>
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
                        <button class="button" type="submit" data-type="primary" data-size="medium">Подтвердить</button>
                    </div>
                </form>
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

        //function closereviews() {
        //    const reviewsPanel = reviewsContainer.querySelector('.object[data-type="mobile"]');
        //    const background = reviewsContainer.querySelector('.background');
        //    background.style.opacity = '0';
        //    reviewsPanel.style.transform = 'translateY(-100%)';

        //    setTimeout(() => {
        //        reviewsContainer.remove();

        //        document.body.style.overflow = '';
        //        document.body.style.overscrollBehavior = '';
        //        document.body.style.position = '';
        //        document.body.style.paddingRight = '';
        //    }, 300);
        //}

        AddVisitorReview();
    });
});

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

function AddVisitorReview() {
    var form = document.querySelector('form[data-type="reviews"]');
    form.addEventListener('submit', function (event) {
        event.preventDefault();

        const ratingInputs = form.querySelectorAll('input[type="radio"][name="rating"]');
        let rating = null;
        let inputt;
        ratingInputs.forEach(input => {
            if (input.checked) {
                rating = parseInt(input.id.replace(/\D/g, ''), 10);
                inputt = input;
            }
        });

        const text = form.querySelector('textarea[name="text"]');

        var formData = new FormData();
        formData.append('rating', rating);
        formData.append('text', text.value);

        fetch("/AddReview", {
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
                inputt.checked = false;
                text.value = "";
                closereviews();
                setTimeout(() => {
                    location.reload();
                }, 200);
                console.log(message);
            })
            .catch(error => {
                console.log(error);
            });
    });
}
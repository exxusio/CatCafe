using BusinessLayer;
using DataAccessLayer.Entities;
using PresentationLayer.Models;

namespace PresentationLayer.Services
{
    public class ReviewsService
    {
        private DataManager _dataManager;
        private VisitorsService _visitorsService;

        public ReviewsService(DataManager dataManager)
        {
            _dataManager = dataManager;
            _visitorsService = new VisitorsService(dataManager);
        }

        public async Task<ICollection<ViewReviews>> GetList()
        {
            var reviews = await _dataManager.reviews.GetAll();
            List<ViewReviews> reviewsList = new List<ViewReviews>();

            foreach (var item in reviews)
                reviewsList.Add(await GetViewById(item.ID));

            return reviewsList;
        }

        public async Task<ViewReviews> GetViewById(int ID)
        {
            var review = await _dataManager.reviews.GetById(ID, true);

            ViewVisitors visitor = new ViewVisitors();
            visitor = await _visitorsService.GetViewById(review.ID);

            return new ViewReviews()
            {
                ID = review.ID,
                text = review.text,
                date = review.date,
                time = review.time,
                rating = review.rating,
                visitor = visitor
            };
        }

        public async Task<EditReviews> GetEditById(int ID = 0)
        {
            var review = await _dataManager.reviews.GetById(ID);

            return new EditReviews()
            {
                ID = review.ID,
                visitorID = review.visitorID,
                text = review.text,
                date = review.date,
                time = review.time,
                rating = review.rating
            };
        }

        public async Task<ViewReviews> SaveEdit(EditReviews editReview)
        {
            Reviews review;

            if (editReview.ID != 0)
                review = await _dataManager.reviews.GetById(editReview.ID);
            else
                review = new Reviews();

            review.visitorID = editReview.visitorID;
            review.text = editReview.text;
            review.date = editReview.date;
            review.time = editReview.time;
            review.rating = editReview.rating;

            await _dataManager.reviews.Save(review);

            return await GetViewById(review.ID);
        }

        public async Task DeleteView(int ID)
        {
            await _dataManager.reviews.Delete(await _dataManager.reviews.GetById(ID));
        }

        public async Task DeleteView(ViewReviews Review)
        {
            await _dataManager.reviews.Delete(await _dataManager.reviews.GetById(Review.ID));
        }
    }
}

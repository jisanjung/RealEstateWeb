using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeLibrary
{
    public class HomeFeedback
    {
        int _feedback_id, _home_id, _rating;
        string _price_feedback, _location_feedback, _overall_feedback;

        public HomeFeedback() { }

        public HomeFeedback(int feedback_id, int home_id, int rating, string price_feedback, string location_feedback, string overall_feedback)
        {
            _feedback_id = feedback_id;
            _home_id = home_id;
            _rating = rating;
            _price_feedback = price_feedback;
            _location_feedback = location_feedback;
            _overall_feedback = overall_feedback;
        }

        //properties
        public int FeedbackId
        {
            get { return _feedback_id; }
            set { _feedback_id = value; }
        }
        public int HomeId
        {
            get { return _home_id; }
            set { _home_id = value; }
        }
        public int Rating
        {
            get
            {
                return _rating;
            }
            set
            {
                _rating = value;
            }
        }
        public string PriceFeedback
        {
            get { return _price_feedback; }
            set { _price_feedback = value; }
        }
        public string LocationFeedback
        {
            get { return _location_feedback; }
            set
            {
                _location_feedback = value;
            }
        }
        public string OverallFeedback
        {
            get { return _overall_feedback; }
            set { _overall_feedback = value; }
        }
        //functions
    }
}

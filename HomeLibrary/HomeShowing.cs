using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeLibrary
{
    public class HomeShowing
    {
        int _home_showing_id, _home_id;
        string _buyer_email, _seller_email, _date, _time;

        public HomeShowing() { }

        public HomeShowing(int home_showing_id, int home_id, string buyer_email, string seller_email, string date, string time)
        {
            _home_showing_id = home_showing_id;
            _home_id = home_id;
            _buyer_email = buyer_email;
            _seller_email = seller_email;
            _date = date;
            _time = time;
        }

        //properties
        public int ShowingId
        {
            get { return _home_showing_id; }
            set { _home_showing_id = value; }
        }
        public int HomeId
        {
            get { return _home_id; }
            set { _home_id = value; }
        }
        public string BuyerEmail
        {
            get { return _buyer_email; }
            set
            {
                _buyer_email = value;
            }
        }
        public string SellerEmail
        {
            get { return _seller_email; }
            set
            {
                _seller_email = value;
            }
        }
        public string Date
        {
            get { return _date; }
            set
            {
                _date = value;
            }
        }
        public string Time
        {
            get { return _time; }
            set
            {
                _time = value;
            }
        }
        //functions

    }
}

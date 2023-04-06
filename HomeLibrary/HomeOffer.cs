using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeLibrary
{
    public class HomeOffer
    {
        int _home_offer_id, _home_id;
        bool _sell_home_first, _accepted;
        string _sale_type, _contingencies, _move_in_date, _buyer_email, _seller_email;
        float _offer_amount;

        public HomeOffer() { }

        public HomeOffer(int home_offer_id, int home_id, bool sell_home_first, bool accepted, string sale_type, string contingencies, string move_in_date, string buyer_email, string seller_email, float offer_amount)
        {
            _home_id = home_id;
            _home_offer_id = home_offer_id;
            _sell_home_first = sell_home_first;
            _accepted = accepted;
            _sale_type = sale_type;
            _contingencies = contingencies;
            _move_in_date = move_in_date;
            _buyer_email = buyer_email;
            _seller_email = seller_email;
            _offer_amount = offer_amount;
        }

        //properties
        public int HomeOfferId
        {
            get { return _home_offer_id; }
            set { _home_offer_id = value; }
        }
        public int HomeId
        {
            get { return _home_id; }
            set { _home_id = value; }
        }
        public bool SellHomeFirst
        {
            get { return _sell_home_first; }
            set
            {
                _sell_home_first = value;
            }
        }
        public bool Accepted
        {
            get { return _accepted; }
            set
            {
                _accepted = value;
            }
        }
        public string SaleType
        {
            get { return _sale_type; }
            set
            {
                _sale_type = value;
            }
        }
        public string Contingencies
        {
            get { return _contingencies; }
            set
            {
                _contingencies = value;
            }
        }
        public string MoveInDate
        {
            get { return _move_in_date; }
            set
            {
                _move_in_date = value;
            }
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
        public float OfferAmount
        {
            get { return _offer_amount; }
            set { _offer_amount = value; }
        }

        //functions
    }
}

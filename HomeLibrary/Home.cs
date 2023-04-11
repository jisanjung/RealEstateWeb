using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace HomeLibrary
{
    public class Home
    {
        int _home_id, _zip_code, _house_size, _year_built;
        float _price, _number_bed, _number_bath, _rating;
        string _seller_email, _address, _property_type, _other_amenities, _status, _hvac, _garage, _utilities, _img, _img_caption, _description, _company_name;
        private List<Room> _rooms = new List<Room>();

        public Home() { }

        public Home(int home_id, int zip_code, int house_size, float price,
                    float number_bed, float number_bath, float rating, string seller_email,
                    string address, string property_type, string other_amenities, string status, int year_built, List<Room> rooms, string hvac, string garage, string utilities, string img, string img_caption, string description, string company_name)
        {
            _home_id = home_id;
            _zip_code = zip_code;
            _house_size = house_size;
            _price = price;
            _number_bed = number_bed;
            _number_bath = number_bath;
            _rating = rating;
            _seller_email = seller_email;
            _address = address;
            _property_type = property_type;
            _other_amenities = other_amenities;
            _status = status;
            _year_built = year_built;
            _rooms = rooms;
            _hvac = hvac;
            _garage = garage;
            _utilities = utilities;
            _img = img;
            _img_caption = img_caption;
            _description = description;
            _company_name = company_name;
        }

        //properties
        public int HomeId
        {
            get { return _home_id; }
            set { _home_id = value; }
        }
        public int ZipCode
        {
            get { return _zip_code; }
            set { _zip_code = value; }
        }
        public int HouseSize
        {
            get { return _house_size; }
            set { _house_size = value; }
        }
        public int YearBuilt
        {
            get { return _year_built; }
            set { _year_built = value; }
        }
        public float Price
        {
            get { return _price; }
            set
            {
                _price = value;
            }
        }
        public float NumberBed
        {
            get { return _number_bed; }
            set
            {
                _number_bed = value;
            }
        }
        public float NumberBath
        {
            get { return _number_bath; }
            set
            {
                _number_bath = value;
            }
        }
        public List<Room> Rooms
        {
            get { return this._rooms; }
            set { this._rooms = value; }
        }
        public float Rating
        {
            get { return _rating; }
            set
            {
                _rating = value;
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
        public string Address
        {
            get { return _address; }
            set
            {
                _address = value;
            }
        }
        public string PropertyType
        {
            get { return _property_type; }
            set
            {
                _property_type = value;
            }
        }
        public string OtherAmenities
        {
            get { return _other_amenities; }
            set
            {
                _other_amenities = value;
            }
        }
        public string HVAC
        {
            get { return _hvac; }
            set
            {
                _hvac = value;
            }
        }
        public string Garage
        {
            get { return _garage; }
            set
            {
                _garage = value;
            }
        }
        public string Utilities
        {
            get { return _utilities; }
            set
            {
                _utilities = value;
            }
        }
        public string Img
        {
            get { return _img; }
            set
            {
                _img = value;
            }
        }
        public string ImgCaption
        {
            get { return _img_caption; }
            set
            {
                _img_caption = value;
            }
        }
        public string Status
        {
            get { return _status; }
            set
            {
                _status = value;
            }
        }
        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
            }
        }
        public string CompanyName
        {
            get { return this._company_name; }
            set { this._company_name = value; }
        }

        //functions
    }
}

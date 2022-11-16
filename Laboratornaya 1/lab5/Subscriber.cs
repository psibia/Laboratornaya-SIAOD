using System;

namespace Laboratornaya_1.lab5
{
    public class Subscriber
    {
        public string Name { get; set; }
        public int PhoneNumber { get; set; }
        public int Adress { get; set; }
        public Subscriber(string name, int phoneNumber, int adress)
        {
            Name = name;
            PhoneNumber = phoneNumber;
            Adress = adress;
        }
    }
}

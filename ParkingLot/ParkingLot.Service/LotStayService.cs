using ParkingLot.Common;
using ParkingLot.Data;
using ParkingLot.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot.Service
{
    public class LotStayService
    {
        //return list of lot stays for customer dto object
        public IEnumerable<LotStayDto> GetCustomerLotStayList(int i)
        {
            using (parkinglotEntities db = new parkinglotEntities())
            {
                //FullNameService fname = new FullNameService();
                var lotstays =
                    db.LotStays.Where(l => l.IsDeleted == false || l.IsDeleted == null)
                        .Where(l => l.KeyCard.CustomerKey == i)
                        .Select(l => new LotStayDto
                        {
                            LotStayKey = l.LotStayKey
                            ,
                            CustomerFirstName = l.KeyCard.Customer.FirstName
                            ,
                            CustomerLastName = l.KeyCard.Customer.LastName
                            ,
                            KeyCardKey = l.KeyCardKey
                            ,
                            ParkingSpotNumber = l.ParkingSpotKey
                            ,
                            ParkingLotNumber = l.ParkingSpot.ParkingLotKey
                            ,
                            StartStay = l.StartStay
                            ,
                            EndStay = l.EndStay
                            ,
                            StayCost = l.StayCost
                            ,
                            CustomerKey = l.KeyCard.CustomerKey
                        }).ToList();
                //TODO write method for building array of keys

                return lotstays;
            }
            
        }

        //get details for lot stay and list
        public LotStayDto GetLotStayDetails(int l, int c)
        {
            using (parkinglotEntities db = new parkinglotEntities())
            {
                LotStay lotstay =
                    db.LotStays
                    .Where(s => s.IsDeleted == false || s.IsDeleted == null)
                    .Where(s => s.KeyCard.CustomerKey == c)
                    .FirstOrDefault(s => s.LotStayKey == l);

                if (lotstay == null)
                {
                    return null;
                }
                else
                {
                    LotStayDto staydto = new LotStayDto();
                    staydto.LotStayKey = lotstay.LotStayKey;
                    staydto.ParkingSpotNumber = lotstay.ParkingSpotKey;
                    staydto.ParkingLotNumber = lotstay.ParkingSpot.ParkingLotKey;
                    staydto.KeyCardKey = lotstay.KeyCardKey;
                    staydto.StartStay = lotstay.StartStay;
                    staydto.EndStay = lotstay.EndStay;
                    staydto.CustomerFirstName = lotstay.KeyCard.Customer.FirstName;
                    staydto.CustomerLastName = lotstay.KeyCard.Customer.LastName;
                    staydto.CustomerKey = lotstay.KeyCard.CustomerKey;
                    staydto.StayCost = lotstay.StayCost;

                    //return object
                    return staydto;
                }
            }
        }

        //add new lotstay
        public void AddLotStay (LotStayDto newstay)
        {
            Helper helper = new Helper();
            using (parkinglotEntities db = new parkinglotEntities())
            {

                LotStay lotstay = new LotStay();
                lotstay.StartStay = newstay.StartStay;
                lotstay.EndStay = newstay.EndStay;
                lotstay.KeyCardKey = newstay.KeyCardKey;
                lotstay.ParkingSpotKey = newstay.KeyCardKey;
                if (newstay.EndStay != null)
                {
                    lotstay.StayCost = helper.CalculateStayCost(newstay.StartStay, newstay.EndStay);
                }
                else
                {
                    lotstay.StayCost = null;
                }
                db.LotStays.Add(lotstay);
                db.SaveChanges();
            } 
        }

        //edit lotstay
        public void EditLotStay (LotStayDto lotstay)
        {
            Helper helper  = new Helper();
            using (parkinglotEntities db = new parkinglotEntities())
            {
                //new version
                var editedstay = db.LotStays.FirstOrDefault(l => l.LotStayKey == lotstay.LotStayKey);
                editedstay.StartStay = lotstay.StartStay;
                editedstay.EndStay = lotstay.EndStay;
                editedstay.KeyCardKey = lotstay.KeyCardKey;
                editedstay.ParkingSpotKey = lotstay.ParkingSpotNumber;
                if (lotstay.EndStay != null)
                {
                    editedstay.StayCost = helper.CalculateStayCost(lotstay.StartStay, lotstay.EndStay);
                }
                else
                {
                    editedstay.StayCost = null;
                }
                db.Entry(editedstay).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }  
        }

        //perform soft delete for selected lotstay
        public static void DeleteLotStay (int l)
        {
            using (parkinglotEntities db = new parkinglotEntities())
            {
                var lotstay =
                    db.LotStays
                    .FirstOrDefault(s => s.LotStayKey.Equals(l));
                lotstay.IsDeleted = true;
                db.SaveChanges();
            }
        }

        //grabs a keycard key for lotstay generation
        public int GetKeyCard(int custkey)
        {
            using (parkinglotEntities db = new parkinglotEntities())
            {                
                int keycard = db.KeyCards.FirstOrDefault(k => k.CustomerKey.Equals(custkey)).KeyCardKey;
                return keycard;
            }
        }
    }
}

using TrainTickets.Models;

namespace TrainTickets.Data {
    public class DbInitializer {
        public static readonly string PLATZCART = "Platzcart";
        public static readonly string KUPE = "Kupe";
        public static void Initialize(TrainTicketsContext context) {
            if (context.Station.Any()) {
                return;
            }

            var stations = new Station[] {
                new Station{Name="Almaty"},
                new Station{Name="Nur-Sultan" },
                new Station{Name="Shymkent"},
                new Station{Name="Taraz"},
                new Station{Name="Kostanai"},
                new Station{Name="Pavlodar"},
                new Station{Name="Kyzylorda"},
                new Station{Name="Petropavlovsk" },
                new Station{Name="Uralsk" },
                new Station {Name="Aktobe"},
                new Station{Name="Semei" }
            };
            context.Station.AddRange(stations);
            context.SaveChanges();

            var trains = new Train[] {
                new Train{Name="043T"},
                new Train{Name="009T" },
                new Train{Name="015T"},
                new Train{Name="034T" },
                new Train{Name="025T" }
            };
            context.Train.AddRange(trains);
            context.SaveChanges();

            var trainStations = new TrainStation[] {
                new TrainStation{TrainID=1, StationID=1, Ordinal=1,
                    ArrivalAt=new DateTime(2022, 4, 30, 12, 30, 0), DepartureAt=new DateTime(2022, 4, 30, 12, 40, 0)},
                new TrainStation{TrainID=1, StationID=2, Ordinal=2,
                    ArrivalAt=new DateTime(2022, 5, 1, 12, 35, 0), DepartureAt=new DateTime(2022, 5, 1, 12, 45, 0)},
                new TrainStation{TrainID=1, StationID=3, Ordinal=3,
                    ArrivalAt=new DateTime(2022, 5, 2, 12, 30, 0), DepartureAt=new DateTime(2022, 5, 2, 12, 40, 0)},
                new TrainStation{TrainID=1, StationID=4, Ordinal=4,
                    ArrivalAt=new DateTime(2022, 5, 3, 12, 30, 0), DepartureAt=new DateTime(2022, 5, 3, 12, 40, 0)},
                new TrainStation{TrainID=1, StationID=5, Ordinal=5,
                    ArrivalAt=new DateTime(2022, 5, 4, 12, 30, 0), DepartureAt=new DateTime(2022, 5, 4, 12, 40, 0)},

                new TrainStation{TrainID=2, StationID=1, Ordinal=1,
                    ArrivalAt=new DateTime(2022, 4, 30, 18, 20, 0), DepartureAt=new DateTime(2022, 4, 30, 18, 30, 0)},
                new TrainStation{TrainID=2, StationID=2, Ordinal=2,
                    ArrivalAt=new DateTime(2022, 5, 1, 17, 30, 0), DepartureAt=new DateTime(2022, 5, 1, 12, 40, 0)},
                new TrainStation{TrainID=2, StationID=3, Ordinal=3,
                    ArrivalAt=new DateTime(2022, 5, 2, 12, 30, 0), DepartureAt=new DateTime(2022, 5, 2, 12, 40, 0)},
                new TrainStation{TrainID=2, StationID=4, Ordinal=4,
                    ArrivalAt=new DateTime(2022, 5, 3, 12, 30, 0), DepartureAt=new DateTime(2022, 5, 3, 12, 40, 0)},
                new TrainStation{TrainID=2, StationID=5, Ordinal=5,
                    ArrivalAt=new DateTime(2022, 5, 4, 12, 30, 0), DepartureAt=new DateTime(2022, 5, 4, 12, 40, 0)},

                new TrainStation{TrainID=3, StationID=1, Ordinal=1,
                    ArrivalAt=new DateTime(2022, 4, 30, 20, 0, 0), DepartureAt=new DateTime(2022, 4, 30, 20, 12, 0)},
                new TrainStation{TrainID=3, StationID=2, Ordinal=2,
                    ArrivalAt=new DateTime(2022, 5, 1, 22, 0, 0), DepartureAt=new DateTime(2022, 5, 1, 22, 30, 0)},
                new TrainStation{TrainID=3, StationID=3, Ordinal=3,
                    ArrivalAt=new DateTime(2022, 5, 2, 12, 30, 0), DepartureAt=new DateTime(2022, 5, 2, 12, 40, 0)},
                new TrainStation{TrainID=3, StationID=4, Ordinal=4,
                    ArrivalAt=new DateTime(2022, 5, 3, 12, 30, 0), DepartureAt=new DateTime(2022, 5, 3, 12, 40, 0)},
                new TrainStation{TrainID=3, StationID=5, Ordinal=5,
                    ArrivalAt=new DateTime(2022, 5, 4, 12, 30, 0), DepartureAt=new DateTime(2022, 5, 4, 12, 40, 0)},

                new TrainStation{TrainID=4, StationID=1, Ordinal=1,
                    ArrivalAt=new DateTime(2022, 4, 30, 9, 0, 0), DepartureAt=new DateTime(2022, 4, 30, 9, 15, 0)},
                new TrainStation{TrainID=4, StationID=2, Ordinal=2,
                    ArrivalAt=new DateTime(2022, 5, 1, 16, 10, 0), DepartureAt=new DateTime(2022, 5, 1, 16, 25, 0)},
                new TrainStation{TrainID=4, StationID=3, Ordinal=3,
                    ArrivalAt=new DateTime(2022, 5, 2, 12, 30, 0), DepartureAt=new DateTime(2022, 5, 2, 12, 40, 0)},
                new TrainStation{TrainID=4, StationID=4, Ordinal=4,
                    ArrivalAt=new DateTime(2022, 5, 3, 12, 30, 0), DepartureAt=new DateTime(2022, 5, 3, 12, 40, 0)},
                new TrainStation{TrainID=4, StationID=5, Ordinal=5,
                    ArrivalAt=new DateTime(2022, 5, 4, 12, 30, 0), DepartureAt=new DateTime(2022, 5, 4, 12, 40, 0)},

                new TrainStation{TrainID=5, StationID=1, Ordinal=1,
                    ArrivalAt=new DateTime(2022, 4, 30, 10, 30, 0), DepartureAt=new DateTime(2022, 4, 30, 10, 45, 0)},
                new TrainStation{TrainID=5, StationID=2, Ordinal=2,
                    ArrivalAt=new DateTime(2022, 5, 1, 12, 35, 0), DepartureAt=new DateTime(2022, 5, 1, 13, 0, 0)},
                new TrainStation{TrainID=5, StationID=3, Ordinal=3,
                    ArrivalAt=new DateTime(2022, 5, 2, 12, 30, 0), DepartureAt=new DateTime(2022, 5, 2, 12, 40, 0)},
                new TrainStation{TrainID=5, StationID=4, Ordinal=4,
                    ArrivalAt=new DateTime(2022, 5, 3, 12, 30, 0), DepartureAt=new DateTime(2022, 5, 3, 12, 40, 0)},
                new TrainStation{TrainID=5, StationID=5, Ordinal=5,
                    ArrivalAt=new DateTime(2022, 5, 4, 12, 30, 0), DepartureAt=new DateTime(2022, 5, 4, 12, 40, 0)},
            };
            context.TrainStation.AddRange(trainStations);
            context.SaveChanges();

            var coaches = new Coach[] {
                new Coach{TrainID=1, CoachNumber=1, Type=PLATZCART, PriceTenge=5630 },
                new Coach{TrainID=1, CoachNumber=2, Type=PLATZCART, PriceTenge=5725 },
                new Coach{TrainID=1, CoachNumber=3, Type=KUPE, PriceTenge=8318 },
                new Coach{TrainID=1, CoachNumber=4, Type=KUPE, PriceTenge=8326 },
                                     
                new Coach{TrainID=2, CoachNumber=1, Type=PLATZCART, PriceTenge=5730 },
                new Coach{TrainID=2, CoachNumber=2, Type=PLATZCART, PriceTenge=5925 },
                new Coach{TrainID=2, CoachNumber=3, Type=KUPE, PriceTenge=9314 },
                new Coach{TrainID=2, CoachNumber=4, Type=KUPE, PriceTenge=9422 },
                                      
                new Coach{TrainID=3, CoachNumber=1, Type=PLATZCART, PriceTenge=6005 },
                new Coach{TrainID=3, CoachNumber=2, Type=PLATZCART, PriceTenge=5345 },
                new Coach{TrainID=3, CoachNumber=3, Type=KUPE, PriceTenge=8756 },
                new Coach{TrainID=3, CoachNumber=4, Type=KUPE, PriceTenge=8343 },
                                      
                new Coach{TrainID=4, CoachNumber=1, Type=PLATZCART, PriceTenge=5430 },
                new Coach{TrainID=4, CoachNumber=2, Type=PLATZCART, PriceTenge=5560 },
                new Coach{TrainID=4, CoachNumber=3, Type=KUPE, PriceTenge=9034 },
                new Coach{TrainID=4, CoachNumber=4, Type=KUPE, PriceTenge=8685 },
                                     
                new Coach{TrainID=5, CoachNumber=1, Type=PLATZCART, PriceTenge=5456 },
                new Coach{TrainID=5, CoachNumber=2, Type=PLATZCART, PriceTenge=5234 },
                new Coach{TrainID=5, CoachNumber=3, Type=KUPE, PriceTenge=8345 },
                new Coach{TrainID=5, CoachNumber=4, Type=KUPE, PriceTenge=8436 },
            };
            context.Coach.AddRange(coaches);
            context.SaveChanges();


            const int NUM_PLACES_IN_COACH = 24;
            List<Place> places = new List<Place>();
            //Place[] places = new Place[coaches.Length * NUM_PLACES_IN_COACH];
            for (int i = 0; i < coaches.Length; i++) {
                for (int j = 0; j < NUM_PLACES_IN_COACH; j++) {
                    string placeType = j % 2 == 0 ? "Bottom" : "Top";
                    //places[i * coaches.Length + j] = new Place { CoachID = i + 1, PlaceNumber = j + 1, Type = placeType, IsFree = true };
                    places.Add(new Place { CoachID = i + 1, PlaceNumber = j + 1, Type = placeType, IsFree = false });
                }
            }
            context.Place.AddRange(places);
            context.SaveChanges();
        }
    }
}

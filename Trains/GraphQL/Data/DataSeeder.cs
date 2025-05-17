using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bogus;
using static HotChocolate.ErrorCodes;
//using Faker;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GraphQL.Data
{
    public class DataSeeder
    {
        public static void SeedData(TrainDbContext db)
        {
            if (!db.Passengers.Any())
            {
                for (int i = 1; i <= 5; i++)
                {
                    var passenger = new Passenger
                    {
                        FirstName = $"First {i}",
                        LastName = $"Last {i}",
                        Email = $"abc{i*i}@mail.ru",
                    };
                    db.Passengers.Add(passenger);
                }
            }

            if (!db.Sellers.Any())
            {
                for (int i = 1; i <= 3; i++)
                {
                    var seller = new Seller
                    {
                        Name = "Seller" + i,
                        PhoneNumber = "123-456-78" + i,
                    };
                    db.Sellers.Add(seller);
                }
            }

            if (!db.Trains.Any())
            {
                for (int i = 1; i <= 2; i++)
                {
                    var train = new Train
                    {
                        TrainNumber = "TR" + (100 + i)
                    };
                    db.Trains.Add(train);
                }
            }

            db.SaveChanges(); // Сохраняем изменения, чтобы получить ID для последующих зависимостей

            // Создаем вагоны
            if (!db.Carriages.Any())
            {
                var train1 = db.Trains.FirstOrDefault(t => t.TrainNumber == "TR101");
                var train2 = db.Trains.FirstOrDefault(t => t.TrainNumber == "TR102");

                var carriage1 = new Carriage { TrainId = train1.Id, CarriageType = "FirstClass" };
                var carriage2 = new Carriage { TrainId = train1.Id, CarriageType = "SecondClass" };
                var carriage3 = new Carriage { TrainId = train2.Id, CarriageType = "ThirdClass" };

                db.Carriages.AddRange(new[] { carriage1, carriage2, carriage3 });
            }

            db.SaveChanges();

            // Создаем сиды для мест в вагонах
            if (!db.Seats.Any())
            {
                var carriage1 = db.Carriages.FirstOrDefault(c => c.CarriageType == "FirstClass");
                var carriage2 = db.Carriages.FirstOrDefault(c => c.CarriageType == "SecondClass");
                var carriage3 = db.Carriages.FirstOrDefault(c => c.CarriageType == "ThirdClass");

                for (int i = 1; i <= 5; i++)
                {
                    db.Seats.AddRange(new[]
                    {
                    new Seat { CarriageId = carriage1.Id, Price = 100, IsAvailable = true },
                    new Seat { CarriageId = carriage2.Id, Price = 50, IsAvailable = true },
                    new Seat { CarriageId = carriage3.Id, Price = 30, IsAvailable = true }
                });
                }
            }

            db.SaveChanges();

            // Создаем билеты
            if (!db.Tickets.Any())
            {
                var passenger1 = db.Passengers.FirstOrDefault(p => p.FirstName == "John");
                var passenger2 = db.Passengers.FirstOrDefault(p => p.FirstName == "Jane");
                var seller1 = db.Sellers.FirstOrDefault(s => s.Name == "Seller1");
                var seller2 = db.Sellers.FirstOrDefault(s => s.Name == "Seller2");
                var seat1 = db.Seats.FirstOrDefault(s => s.Price == 100);
                var seat2 = db.Seats.FirstOrDefault(s => s.Price == 50);
                var train1 = db.Trains.FirstOrDefault(t => t.TrainNumber == "TR101");

                db.Tickets.AddRange(new[]
                {
                new Ticket
                {
                    PassengerId = passenger1.Id,
                    SellerId = seller1.Id,
                    SeatId = seat1.Id,
                    PurchaseDate = DateTime.Now,
                    TrainId = train1.Id
                },
                new Ticket
                {
                    PassengerId = passenger2.Id,
                    SellerId = seller2.Id,
                    SeatId = seat2.Id,
                    PurchaseDate = DateTime.Now,
                    TrainId = train1.Id
                }
            });
            }

            db.SaveChanges();
        }
    }


        //    public static void SeedData(TrainDbContext db)
        //    {
        //        //if (db.Passengers.Count() == 0)
        //        //{
        //            for (int i = 0; i < 10; i++)
        //            {
        //                // Создание пассажира
        //                var pasenger = new Passenger
        //                {
        //                    FirstName = $"PassengerFirstName{i + 1}",
        //                    LastName = $"PassengerLastName{i + 1}",
        //                    Email = $"passenger{i + 1}@example.com"
        //                };
        //                db.Passengers.Add(pasenger);

        //                // Создание продавца
        //                var seller = new Seller
        //                {
        //                    Name = $"SellerName{i + 1}",
        //                    PhoneNumber = $"555-0123-{i + 1:D4}"
        //                };
        //                db.Sellers.Add(seller);

        //                // Создание поезда
        //                var train = new Train
        //                {
        //                    TrainNumber = $"Train-{i + 1}"
        //                };
        //                db.Trains.Add(train);

        //                // Создание вагонов для поезда
        //                for (int j = 0; j < 3; j++) // Каждый поезд будет иметь 3 вагона
        //                {
        //                    var carriage = new Carriage
        //                    {
        //                        Train = train,
        //                        CarriageType = j % 2 == 0 ? "Economy" : "First Class"
        //                    };
        //                    db.Carriages.Add(carriage);

        //                    // Создание мест для вагона
        //                    for (int k = 0; k < 10; k++) // Каждый вагон будет иметь 10 мест
        //                    {
        //                        var seat = new Seat
        //                        {
        //                            Carriage = carriage,
        //                            Price = (decimal)(50 + (j * 20)), // Цена зависит от типа вагона
        //                            IsAvailable = true
        //                        };
        //                        db.Seats.Add(seat);

        //                        // Создание билета для пассажира
        //                        if (k % 2 == 0) // Создаем билеты для каждого второго места
        //                        {
        //                            var ticket = new Ticket
        //                            {
        //                                Passenger = pasenger,
        //                                Seller = seller,
        //                                Seat = seat,
        //                                PurchaseDate = DateTime.Now,
        //                                Train = train
        //                            };
        //                            db.Tickets.Add(ticket);
        //                        }
        //                    }
        //                }
        //            }
        //            // Сохраняем изменения в базе данных
        //            db.SaveChanges();
        //        //}
        //    }
    }

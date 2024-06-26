﻿using Entities.Domain;
using OrganizationTrackingApplicationData.GenericRepository.Abstract;
using System.Data.Entity;

namespace OrganizationTrackingApplicationApi.Application.DummyCommand
{
    public class DummyCommand : IDummyCommand
    {
        private readonly IGenericRepository<Event> _eventRepository;
        private readonly IGenericRepository<User> _userRepository;
        private readonly IGenericRepository<Ticket> _ticketRepository;
        private readonly IGenericRepository<EventType> _eventTypeRepository;
        private readonly IGenericRepository<Location> _locationRepository;
        private readonly IGenericRepository<Rating> _ratingRepository;

        public DummyCommand(
            IGenericRepository<Event> eventRepository,
            IGenericRepository<User> userRepository,
            IGenericRepository<Ticket> ticketRepository,
            IGenericRepository<EventType> eventTypeRepository,
            IGenericRepository<Location> locationRepository,
            IGenericRepository<Rating> ratingRepository)
        {
            _eventRepository = eventRepository;
            _userRepository = userRepository;
            _ticketRepository = ticketRepository;
            _eventTypeRepository = eventTypeRepository;
            _locationRepository = locationRepository;
            _ratingRepository = ratingRepository;
        }

        public async Task AddDummyData()
        {
            for (int i = 0; i < 2000; i++)
            {
                if (i < 1000)
                {
                    var userToBeAdded = new User("GirlName" + i, "GirlSurname" + i, $"girlMail{i}@mail.com", "12345", false, (int)new Random().NextInt64(18, 50));
                    await _userRepository.Insert(userToBeAdded);
                }
                else
                {
                    var userToBeAdded = new User("BoyName" + i, "BoySurname" + i, $"boyMail{i}@mail.com", "12345", true, (int)new Random().NextInt64(18, 50));
                    await _userRepository.Insert(userToBeAdded);
                }
            }

            for (int i = 0; i < 20; i++)
            {
                var location = new Location("location description " + i, "Location formatted Name " + i, (float)15.2221 + ((float)(0.001) * (float)i), (float)11.1221 + ((float)(0.001) * (float)i));
                await _locationRepository.Insert(location);
            }

            var resultDates = GenerateRandomDates(50);

            int datecount = 1;
            foreach (var date in resultDates)
            {
                var allUsersAsOrganizator = await _userRepository.GetSet();
                var allUserWithOrg = allUsersAsOrganizator.Include(a => a.Organizator).ToList();

                var allLocations = await _locationRepository.GetAll();

                var alleventTypes = await _eventTypeRepository.GetAll();

                var eventToAdded = new Event("Event " + datecount, date, GetRandomElement(allLocations.ToList()).Id, GetRandomElement(alleventTypes.ToList()).Id, GetRandomElement(allUserWithOrg).Organizator.Id, (int)new Random().NextInt64(50, 250), (int)new Random().NextInt64(150, 250),"Event description");
                await _eventRepository.Insert(eventToAdded);
                datecount++;
            }

            var eventSet = await _eventRepository.GetSet();
            var allEventsWithTickets =
               eventSet.Include(e => e.Tickets)
               .Include(a => a.EventType)
               .ToList();

            var allUsersRep = await _userRepository.GetAll();
            var allUsers = allUsersRep.ToList();

            foreach (var eventToBeDone in allEventsWithTickets)
            {
                if (eventToBeDone.EventType.Name.Equals("Concert"))
                {
                    var usersForConcert = GetRandomUsers(allUsers, eventToBeDone.Tickets.Count, 22, 35, 45);

                    for (int i = 0; i < usersForConcert.Count; i++)
                    {
                        eventToBeDone.Tickets.ElementAt(i).BuyTicket(usersForConcert.ElementAt(i).Id);
                        await _ticketRepository.SaveChangesAsync();
                    }
                }

                if (eventToBeDone.EventType.Name.Equals("Carnival"))
                {
                    var usersForConcert = GetRandomUsers(allUsers, eventToBeDone.Tickets.Count, 18, 30, 65);

                    for (int i = 0; i < usersForConcert.Count; i++)
                    {
                        eventToBeDone.Tickets.ElementAt(i).BuyTicket(usersForConcert.ElementAt(i).Id);
                        await _ticketRepository.SaveChangesAsync();
                    }
                }

                if (eventToBeDone.EventType.Name.Equals("Activity"))
                {
                    var usersForConcert = GetRandomUsers(allUsers, eventToBeDone.Tickets.Count, 25, 40, 68);

                    for (int i = 0; i < usersForConcert.Count; i++)
                    {
                        eventToBeDone.Tickets.ElementAt(i).BuyTicket(usersForConcert.ElementAt(i).Id);
                        await _ticketRepository.SaveChangesAsync();
                    }
                }

                if (eventToBeDone.EventType.Name.Equals("Festival"))
                {
                    var usersForConcert = GetRandomUsers(allUsers, eventToBeDone.Tickets.Count, 18, 25, 34);

                    for (int i = 0; i < usersForConcert.Count; i++)
                    {
                        eventToBeDone.Tickets.ElementAt(i).BuyTicket(usersForConcert.ElementAt(i).Id);
                        await _ticketRepository.SaveChangesAsync();
                    }
                }

                if (eventToBeDone.EventType.Name.Equals("Meeting"))
                {
                    var usersForConcert = GetRandomUsers(allUsers, eventToBeDone.Tickets.Count, 30, 45, 50);

                    for (int i = 0; i < usersForConcert.Count; i++)
                    {
                        eventToBeDone.Tickets.ElementAt(i).BuyTicket(usersForConcert.ElementAt(i).Id);
                        await _ticketRepository.SaveChangesAsync();
                    }
                }

                if (eventToBeDone.EventType.Name.Equals("Trip"))
                {
                    var usersForConcert = GetRandomUsers(allUsers, eventToBeDone.Tickets.Count, 19, 45, 65);

                    for (int i = 0; i < usersForConcert.Count; i++)
                    {
                        eventToBeDone.Tickets.ElementAt(i).BuyTicket(usersForConcert.ElementAt(i).Id);
                        await _ticketRepository.SaveChangesAsync();
                    }
                }
            }

            //Concert ortalama rastgele
            //Carnival 18 - 30 yaş arası kız ağırlıklı
            //festival 18 - 25 yaş arası erkek ağırlıklı
            //Activity 25 - 40 arası yetişkin kız
            //meeting 30 - 45 arası rastgele
            //trip 18 - 50 arası kadın ağırlıklı

            var ticketSet = await _ticketRepository.GetByFilter(t => !t.OwnerId.Equals(null));
            var ticketList = ticketSet.ToList();

            Random rndom = new Random();

            foreach (var ticket in ticketList)
            {
                var minInterval = (int)rndom.NextInt64(1, 6);
                var ratePoint = PointCreate(minInterval);
                await _ratingRepository.Insert(new Rating(ticket.OwnerId, ratePoint, "Comment", ticket.EventId));
            }
        }

        private static T GetRandomElement<T>(List<T> list)
        {
            Random rnd = new Random();
            int index = rnd.Next(list.Count);
            return list[index];
        }

        public static List<T> GetRandomElements<T>(List<T> list, int elementsCount)
        {
            Random random = new Random();
            return list.OrderBy(x => random.Next()).Take(elementsCount).ToList();
        }

        public static List<User> GetRandomUsers(List<User> users, int numberOfUsers, int minAge, int maxAge, int femalePercentage)
        {
            Random random = new Random();
            // Yaş aralığına göre kullanıcıları filtrele
            List<User> filteredUsers = users.Where(u => u.Age >= minAge && u.Age <= maxAge).ToList();

            // Kadın kullanıcıların oranını hesapla ve seç
            int femaleCount = (int)Math.Ceiling(numberOfUsers * (femalePercentage / 100.0));
            femaleCount = Math.Min(femaleCount, filteredUsers.Count(u => u.Gender)); // Toplam kadın sayısını aşmamak için

            // Rastgele seçilen kadın kullanıcıları al
            List<User> selectedFemales = filteredUsers.Where(u => u.Gender).OrderBy(x => random.Next()).Take(femaleCount).ToList();
            // Kadın kullanıcıları listeden çıkar
            filteredUsers = filteredUsers.Except(selectedFemales).ToList();
            // Geri kalan kullanıcılar arasından rastgele seçim yap
            List<User> selectedOthers = filteredUsers.OrderBy(x => random.Next()).Take(numberOfUsers - femaleCount).ToList();

            // Sonuç listesini oluştur ve karıştır
            List<User> result = selectedFemales.Concat(selectedOthers).OrderBy(x => random.Next()).ToList();

            return result;
        }

        public static int PointCreate(int minValue)
        {
            Random random = new Random();
            // 1 ile 5 arasında rastgele bir double değer üret
            int randomValue = (int)random.NextInt64(minValue, 5); // NextDouble 0 (dahil) ile 1 (hariç) arasında bir değer döndürür
            return randomValue;
        }

        public static List<DateTime> GenerateRandomDates(int numberOfDates)
        {
            List<DateTime> dates = new List<DateTime>();
            Random rnd = new Random();
            int summerDatesCount = 0;
            int weekendSummerDatesCount = 0;

            while (dates.Count < numberOfDates)
            {
                DateTime randomDate = new DateTime(2024, rnd.Next(1, 13), rnd.Next(1, 29));
                if (IsSummer(randomDate) && summerDatesCount < (int)(numberOfDates * 0.68))
                {
                    if (IsWeekend(randomDate) && weekendSummerDatesCount < (int)(summerDatesCount * 0.72))
                    {
                        dates.Add(randomDate);
                        weekendSummerDatesCount++;
                    }
                    else if (!IsWeekend(randomDate))
                    {
                        dates.Add(randomDate);
                    }
                    summerDatesCount++;
                }
                else if (!IsSummer(randomDate))
                {
                    dates.Add(randomDate);
                }
            }
            return dates;
        }

        private static bool IsSummer(DateTime date)
        {
            return (date.Month >= 6 && date.Month <= 8);
        }

        private static bool IsWeekend(DateTime date)
        {
            return (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday);
        }
    }
}
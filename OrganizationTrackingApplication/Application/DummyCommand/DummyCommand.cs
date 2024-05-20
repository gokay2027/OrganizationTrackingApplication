using Entities.Domain;
using MediatR;
using OrganizationTrackingApplicationApi.Model.Event.AddEvent;
using OrganizationTrackingApplicationData.GenericRepository.Abstract;

namespace OrganizationTrackingApplicationApi.Application.DummyCommand
{
    public class DummyCommand
    {
        private readonly IGenericRepository<Event> _eventRepository;
        private readonly IGenericRepository<User> _userRepository;
        private readonly IGenericRepository<Ticket> _ticketRepository;
        private readonly IGenericRepository<EventType> _eventTypeRepository;
        private readonly IGenericRepository<Location> _locationRepository;

        public DummyCommand(IGenericRepository<Event> eventRepository, IGenericRepository<User> userRepository, IGenericRepository<Ticket> ticketRepository, IGenericRepository<EventType> eventTypeRepository, IGenericRepository<Location> locationRepository)
        {
            _eventRepository = eventRepository;
            _userRepository = userRepository;
            _ticketRepository = ticketRepository;
            _eventTypeRepository = eventTypeRepository;
            _locationRepository = locationRepository;
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

            Random rnd = new Random();
            List<DateTime> allDates = new List<DateTime>();
            DateTime startDate = new DateTime(2024, 5, 1);
            DateTime endDate = new DateTime(2024, 12, 31);

            // Yaz ayları ve diğer aylar listeleri
            List<int> summerMonths = new List<int> { 6, 7, 8 }; // Haziran, Temmuz, Ağustos
            List<int> otherMonths = new List<int> { 5, 9, 10, 11, 12 }; // Mayıs, Eylül, Ekim, Kasım, Aralık

            // Tüm tarihler listesini oluştur
            while (startDate <= endDate)
            {
                allDates.Add(startDate);
                startDate = startDate.AddDays(1);
            }

            // Tarihleri rastgele karıştır
            allDates = allDates.OrderBy(date => rnd.Next()).ToList();

            // 50 tarih seçimi
            int totalDates = 50;
            int summerDatesCount = (int)(totalDates * 0.67);
            int otherDatesCount = totalDates - summerDatesCount;

            List<DateTime> summerDates = new List<DateTime>();
            List<DateTime> otherDates = new List<DateTime>();

            // Yaz ayları için tarihler
            foreach (var date in allDates)
            {
                if (summerDatesCount == 0) break;
                if (summerMonths.Contains(date.Month))
                {
                    summerDates.Add(date);
                    summerDatesCount--;
                }
            }

            // Diğer aylar için tarihler
            foreach (var date in allDates)
            {
                if (otherDatesCount == 0) break;
                if (otherMonths.Contains(date.Month))
                {
                    otherDates.Add(date);
                    otherDatesCount--;
                }
            }

            // Yaz aylarından ve diğer aylardan oluşturulan tarihleri birleştir ve sıralar
            List<DateTime> resultDates = summerDates.Concat(otherDates).OrderBy(date => date).ToList();

            int datecount = 1;
            foreach (var date in resultDates)
            {
                var allUsers = await _userRepository.GetAll();
                var topusers = allUsers.Take(15).ToList();

                var allLocations = await _locationRepository.GetAll();

                var alleventTypes = await _eventTypeRepository.GetAll();

                new Event("Event " + datecount, date, GetRandomElement(allLocations.ToList()).Id, GetRandomElement(alleventTypes.ToList()).Id, GetRandomElement(allUsers.ToList()).Id, (int)new Random().NextInt64(50, 500), (int)new Random().NextInt64(150, 500));
                datecount++;
            }


            var teenagers = await _userRepository.GetByFilter(u => u.Age > 18 && u.Age < 30);

            var teenagerGirls = teenagers.Where(a => a.Gender.Equals(false));
            var teenagerBoys = teenagers.Where(a => a.Gender.Equals(true));

            var teenagerGirlsRateCount = teenagerGirls.Count() * 0.64;
            var resultTeenagerGirls = teenagerGirls.Take((int) teenagerGirlsRateCount);

            var teenagerBoysRateCount = teenagerBoys.Count() * 0.22;
            var resultTeenagerBoys = teenagerBoys.Take((int) teenagerBoysRateCount);






        }

        private static T GetRandomElement<T>(List<T> list)
        {
            Random rnd = new Random();
            int index = rnd.Next(list.Count);
            return list[index];
        }
    }
}
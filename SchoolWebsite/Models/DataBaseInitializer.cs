using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace SchoolWebsite.Models
{
    //Class used to Initialize the DB in code first approach.//
    public class DataBaseInitializer:DropCreateDatabaseIfModelChanges<Context>
    {
        //Methods used to fill up the context. They are invoked in overriden Seed method.//
        private void fillListLector(Context ctx)
        {
            List<Lector> lektorzy = new List<Lector>();
            int id = 1;
            lektorzy.Add(new Lector()
            {
                LectorID = id++,
                Name = "Piotr",
                Surname = "Wisnia",
                Title = "Dr",
                Text = "Zalozyciel uczelni super gosc hehe",
                ImageUrl = @"/Images/Lectors/rybka.jpg"
            });
            lektorzy.Add(new Lector()
            {
                LectorID = id++,
                Name = "Maciek",
                Surname = "Tralal",
                Title = "mgr. inż.",
                Text = "Matematyk, wymyslil wszystko co jest w matematyce do wymyslenia",
                ImageUrl = @"/Images/Lectors/rybka.jpg"
            });
            lektorzy.Add(new Lector()
            {
                LectorID = id++,
                Name = "Andrzej",
                Surname = "NieMamNazwiska",
                Title = "Prof.",
                Text = "Ten gosc troche umie programowac ale nie za bardzo",
                ImageUrl = @"/Images/Lectors/rybka.jpg"
            });
            lektorzy.Add(new Lector()
            {
                LectorID = id++,
                Name = "Stefan",
                Surname = "Hehłacz",
                Title = "Dr",
                Text = "Taki sobie tekst bo nie wiem co wpisac",
                ImageUrl = @"/Images/Lectors/rybka.jpg"
            });
            lektorzy.Add(new Lector()
            {
                LectorID = id++,
                Name = "Marek",
                Surname = "Zegarek",
                Title = "Dr",
                Text = "Jestem sobie Marek i mam ładny zegarek :D",
                ImageUrl = @"/Images/Lectors/rybka.jpg"
            });
            lektorzy.Add(new Lector()
            {
                LectorID = id++,
                Name = "Jurek",
                Surname = "Ogórek",
                Title = "Dr",
                Text = "Huehuehuehue",
                ImageUrl = @"/Images/Lectors/rybka.jpg"
            });
            lektorzy.Add(new Lector()
            {
                LectorID = id++,
                Name = "Edward",
                Surname = "Kwarc",
                Title = "Dr",
                Text = "Dobry tekst nie jest zly",
                ImageUrl = @"/Images/Lectors/rybka.jpg"
            });
            foreach (var item in lektorzy)
            {
                ctx.Lectors.Add(item);
            }
            ctx.SaveChanges();

        }
        private void fillListCourse(Context ctx)
        {
            List<Course> kursy = new List<Course>();
            int id = 1;
            kursy.Add(new Course()
            {
                CourseID = id++,
                Name = "Matematyka",
                PeopleLimit = 100,
                Przedmioty = ctx.Przedmioty.Where(p=> p.Specie.Name == "Scisly").ToList(),
                Lectors = ctx.Lectors.ToList()
            });
            kursy.Add(new Course()
            {
                CourseID = id++,
                Name = "Polski",
                PeopleLimit = 50,
                 Przedmioty = ctx.Przedmioty.Where(p=> p.Specie.Name == "Human").ToList(),
                Lectors = ctx.Lectors.ToList()
            });
            kursy.Add(new Course()
            {
                CourseID = id++,
                Name = "Informatyka",
                PeopleLimit = 150,
                Przedmioty = ctx.Przedmioty.Where(p => p.Specie.Name == "Scisly").ToList(),
                Lectors = ctx.Lectors.ToList()
            });
            kursy.Add(new Course()
            {
                CourseID = id++,
                Name = "Historia",
                PeopleLimit = 100,
                Przedmioty = ctx.Przedmioty.Where(p => p.Specie.Name == "Human").ToList(),
                Lectors = ctx.Lectors.ToList()
            });
            foreach (var kurs in kursy)
            {
                ctx.Courses.Add(kurs);
            }
            ctx.SaveChanges();

        }
        private void fillListPrzedmioty(Context ctx)
        {
            List<Przedmiot> przedmioty = new List<Przedmiot>();
            int id= 1;
            przedmioty.Add(new Przedmiot()
            {
                PrzedmiotID=id++,
                Name="Fizyka",
                Specie = ctx.Species.Where(s=> s.Name == "Scisly").FirstOrDefault()
            });
            przedmioty.Add(new Przedmiot()
            {
                PrzedmiotID = id++,
                Name = "Polski",
                Specie = ctx.Species.Where(s => s.Name == "Human").FirstOrDefault()
            });
            przedmioty.Add(new Przedmiot()
            {
                PrzedmiotID = id++,
                Name = "Algebra",
                Specie = ctx.Species.Where(s => s.Name == "Scisly").FirstOrDefault()
            });
            przedmioty.Add(new Przedmiot()
            {
                PrzedmiotID = id++,
                Name = "Statystyka",
                Specie = ctx.Species.Where(s => s.Name == "Scisly").FirstOrDefault()
            });
            przedmioty.Add(new Przedmiot()
            {
                PrzedmiotID = id++,
                Name = "Historia",
                Specie = ctx.Species.Where(s => s.Name == "Human").FirstOrDefault()
            });
            przedmioty.Add(new Przedmiot()
            {
                PrzedmiotID = id++,
                Name = "WOS",
                Specie = ctx.Species.Where(s => s.Name == "Human").FirstOrDefault()
            });
            foreach (var przedmiot in przedmioty)
            {
                ctx.Przedmioty.Add(przedmiot);
            }
            ctx.SaveChanges();
           
        }
        private void fillListSpecies(Context ctx)
        {
            List<Specie> species = new List<Specie>();
            int id = 1;
            species.Add(new Specie()
            {
                SpecieID=id++,
                Name="Scisly"
            });
            species.Add(new Specie()
            {
                SpecieID = id++,
                Name = "Human"
            });
            foreach (var specie in species)
            {
                ctx.Species.Add(specie);
            }
            ctx.SaveChanges();
        }
        //Overriden version of Seed method.//
        protected override void Seed(Context context)
        {
            //Invoking methods used for filling up ctx.
           fillListSpecies(context);
           fillListPrzedmioty(context);
           fillListLector(context);
           fillListCourse(context);
            int id =1;
            var users = new List<User>();
            users.Add(new User() { UserID = id++, Name = "user", Password = "user", Roles = "user" });
            users.Add(new User() { UserID = id++, Name = "admin", Password = "admin", Roles = "admin" });
            context.Users.AddRange(users);
            context.SaveChanges();
            base.Seed(context);
        }
    }
}
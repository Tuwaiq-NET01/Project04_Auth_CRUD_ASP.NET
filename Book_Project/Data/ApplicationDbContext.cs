using Book_Project.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Book_Project.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }


        public DbSet<AuthorModel> Authors { get; set; }
        public DbSet<PublisherModel> Publishers { get; set; }
        public DbSet<BookModel> Books { get; set; }
        public DbSet<BookStoreModel> BookStores { get; set; }
        public DbSet<BookStore_Book_Model> BookStores_Books { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);


            //Authors
            modelBuilder.Entity<AuthorModel>().HasData(new AuthorModel { Id = 1, Name = "Saud" });
            modelBuilder.Entity<AuthorModel>().HasData(new AuthorModel { Id = 2, Name = "Sami" });
            modelBuilder.Entity<AuthorModel>().HasData(new AuthorModel { Id = 3, Name = "Amira" });

            //Publishers
            modelBuilder.Entity<PublisherModel>().HasData(new PublisherModel { Id = 1, Name = "Publisher 1" });
            modelBuilder.Entity<PublisherModel>().HasData(new PublisherModel { Id = 2, Name = "Publisher 2" });
            modelBuilder.Entity<PublisherModel>().HasData(new PublisherModel { Id = 3, Name = "Publisher 3" });


            //Books
            modelBuilder.Entity<BookModel>().HasData(new BookModel
            {
                Id = 1,
                Name = "Saud Book 1",
                Image = "https://www.adazing.com/wp-content/uploads/2019/02/closed-book-clipart-11-300x300.png",
                AuthorId = 1,
                PublisherId = 1,
                Description="One morning, when Gregor Samsa woke from troubled dreams, he found himself transformed in his bed into a horrible vermin. He lay on his armour-like back, and if he lifted his head a little he could see his brown belly, slightly domed and divided by arches into stiff sections. The bedding was hardly able to cover it and seemed ready to slide off any moment. His many legs, pitifully thin compared with the size of the rest of him, waved about helplessly as he looked. What's happened to me? he thought. It wasn't a dream. His room, a proper human room although a little too small, lay peacefully between its four familiar walls. A collection of textile samples lay spread out on the table - Samsa was a travelling salesman - and above it there hung a picture that he had recently cut out of an illustrated magazine and housed in a nice, gilded frame. It showed a lady fitted out with a fur hat and fur boa who sat upright, raising a heavy fur muff that covered the whole of her lower arm towards the viewer. Gregor then turned to look out the window at the dull weather. Drops"
            });

            modelBuilder.Entity<BookModel>().HasData(new BookModel
            {
                Id = 2,
                Name = "Saud Book 2",
                Image = "https://www.adazing.com/wp-content/uploads/2019/02/closed-book-clipart-11-300x300.png",
                AuthorId = 1,
                PublisherId = 3,
                Description= "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Donec quam felis, ultricies nec, pellentesque eu, pretium quis, sem. Nulla consequat massa quis enim. Donec pede justo, fringilla vel, aliquet nec, vulputate eget, arcu. In enim justo, rhoncus ut, imperdiet a, venenatis vitae, justo. Nullam dictum felis eu pede mollis pretium. Integer tincidunt. Cras dapibus. Vivamus elementum semper nisi. Aenean vulputate eleifend tellus. Aenean leo ligula, porttitor eu, consequat vitae, eleifend ac, enim. Aliquam lorem ante, dapibus in, viverra quis, feugiat a, tellus. Phasellus viverra nulla ut metus varius laoreet. Quisque rutrum. Aenean imperdiet. Etiam ultricies nisi vel augue. Curabitur ullamcorper ultricies nisi. Nam eget dui. Etiam rhoncus. Maecenas tempus, tellus eget condimentum rhoncus, sem quam semper libero, sit amet adipiscing sem neque sed ipsum. Nam quam nunc, blandit vel, luctus pulvinar, hendrerit id, lorem. Maecenas nec odio et ante tincidunt tempus. Donec vitae sapien ut libero venenatis faucibus. Nullam quis ante. Etiam sit amet orci eget eros faucibus tincidunt. Duis leo. Sed fringilla mauris sit amet nibh. Donec sodales sagittis magna. Sed consequat, leo eget bibendum sodales, augue velit cursus nunc,"
            });

            modelBuilder.Entity<BookModel>().HasData(new BookModel
            {
                Id = 3,
                Name = "Amira Book 1",
                Image = "https://www.adazing.com/wp-content/uploads/2019/02/closed-book-clipart-05-300x300.png",
                AuthorId = 3,
                PublisherId = 2,
                Description= "Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque ipsa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo. Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit aut fugit, sed quia consequuntur magni dolores eos qui ratione voluptatem sequi nesciunt. Neque porro quisquam est, qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit, sed quia non numquam eius modi tempora incidunt ut labore et dolore magnam aliquam quaerat voluptatem. Ut enim ad minima veniam, quis nostrum exercitationem ullam corporis suscipit laboriosam, nisi ut aliquid ex ea commodi consequatur? Quis autem vel eum iure reprehenderit qui in ea voluptate velit esse quam nihil molestiae consequatur, vel illum qui dolorem eum fugiat quo voluptas nulla pariatur? At vero eos et accusamus et iusto odio dignissimos ducimus qui blanditiis praesentium voluptatum deleniti atque corrupti quos dolores et quas molestias excepturi sint occaecati cupiditate non provident, similique sunt in culpa qui officia deserunt mollitia animi, id est laborum et dolorum fuga. Et harum quidem rerum facilis est et expedita distinctio. Nam libero tempore, cum soluta nobis est eligendi optio cumque nihil impedit quo minus id quod maxime placeat facere"
            });

            modelBuilder.Entity<BookModel>().HasData(new BookModel
            {
                Id = 4,
                Name = "Amira Book 2",
                Image = "https://www.adazing.com/wp-content/uploads/2019/02/closed-book-clipart-05-300x300.png",
                AuthorId = 3,
                PublisherId = 3,
                Description= "But I must explain to you how all this mistaken idea of denouncing pleasure and praising pain was born and I will give you a complete account of the system, and expound the actual teachings of the great explorer of the truth, the master-builder of human happiness. No one rejects, dislikes, or avoids pleasure itself, because it is pleasure, but because those who do not know how to pursue pleasure rationally encounter consequences that are extremely painful. Nor again is there anyone who loves or pursues or desires to obtain pain of itself, because it is pain, but because occasionally circumstances occur in which toil and pain can procure him some great pleasure. To take a trivial example, which of us ever undertakes laborious physical exercise, except to obtain some advantage from it? But who has any right to find fault with a man who chooses to enjoy a pleasure that has no annoying consequences, or one who avoids a pain that produces no resultant pleasure? On the other hand, we denounce with righteous indignation and dislike men who are so beguiled and demoralized by the charms of pleasure of the moment, so blinded by desire, that they cannot foresee"
            });

            modelBuilder.Entity<BookModel>().HasData(new BookModel
            {
                Id = 5,
                Name = "Sami Book 1",
                Image = "https://www.adazing.com/wp-content/uploads/2019/02/closed-book-clipart-07-300x300.png",
                AuthorId = 2,
                PublisherId = 1,
                Description= "Li Europan lingues es membres del sam familie. Lor separat existentie es un myth. Por scientie, musica, sport etc, litot Europa usa li sam vocabular. Li lingues differe solmen in li grammatica, li pronunciation e li plu commun vocabules. Omnicos directe al desirabilite de un nov lingua franca: On refusa continuar payar custosi traductores. At solmen va esser necessi far uniform grammatica, pronunciation e plu sommun paroles. Ma quande lingues coalesce, li grammatica del resultant lingue es plu simplic e regulari quam ti del coalescent lingues. Li nov lingua franca va esser plu simplic e regulari quam li existent Europan lingues. It va esser tam simplic quam Occidental in fact, it va esser Occidental. A un Angleso it va semblar un simplificat Angles, quam un skeptic Cambridge amico dit me que Occidental es.Li Europan lingues es membres del sam familie. Lor separat existentie es un myth. Por scientie, musica, sport etc, litot Europa usa li sam vocabular. Li lingues differe solmen in li grammatica, li pronunciation e li plu commun vocabules. Omnicos directe al desirabilite de un nov lingua franca: On refusa continuar payar custosi traductores. At solmen va esser necessi far uniform grammatica, pronunciation e plu sommun paroles."
            });

            modelBuilder.Entity<BookModel>().HasData(new BookModel
            {
                Id = 6,
                Name = "Sami Book 2",
                Image = "https://www.adazing.com/wp-content/uploads/2019/02/closed-book-clipart-07-300x300.png",
                AuthorId = 2,
                PublisherId = 2,
                Description= "Far far away, behind the word mountains, far from the countries Vokalia and Consonantia, there live the blind texts. Separated they live in Bookmarksgrove right at the coast of the Semantics, a large language ocean. A small river named Duden flows by their place and supplies it with the necessary regelialia. It is a paradisematic country, in which roasted parts of sentences fly into your mouth. Even the all-powerful Pointing has no control about the blind texts it is an almost unorthographic life One day however a small line of blind text by the name of Lorem Ipsum decided to leave for the far World of Grammar. The Big Oxmox advised her not to do so, because there were thousands of bad Commas, wild Question Marks and devious Semikoli, but the Little Blind Text didn’t listen. She packed her seven versalia, put her initial into the belt and made herself on the way. When she reached the first hills of the Italic Mountains, she had a last view back on the skyline of her hometown Bookmarksgrove, the headline of Alphabet Village and the subline of her own road, the Line Lane. Pityful a rethoric question ran over her cheek, then"
            });

            

            //Book Stores

            modelBuilder.Entity<BookStoreModel>().HasData(new BookStoreModel { Id = 1, Name = "Store 1" });
            modelBuilder.Entity<BookStoreModel>().HasData(new BookStoreModel { Id = 2, Name = "Store 2" });
            modelBuilder.Entity<BookStoreModel>().HasData(new BookStoreModel { Id = 3, Name = "Store 3" });



            //BookStores_Books

            modelBuilder.Entity<BookStore_Book_Model>()
            .HasKey(t => new { t.BookStore_ID, t.Book_ID });

            modelBuilder.Entity<BookStore_Book_Model>()
                .HasOne(pt => pt.BookStore)
                .WithMany(p => p.BookStores_Books)
                .HasForeignKey(pt => pt.BookStore_ID);

            modelBuilder.Entity<BookStore_Book_Model>()
                .HasOne(pt => pt.Book)
                .WithMany(p => p.BookStores_Books)
                .HasForeignKey(pt => pt.Book_ID);

            //Book 1 and its stores
            modelBuilder.Entity<BookStore_Book_Model>().HasData(new BookStore_Book_Model { Book_ID = 1, BookStore_ID = 1 });
            modelBuilder.Entity<BookStore_Book_Model>().HasData(new BookStore_Book_Model { Book_ID = 1, BookStore_ID = 2 });

            //Book 2 and its stores
            modelBuilder.Entity<BookStore_Book_Model>().HasData(new BookStore_Book_Model { Book_ID = 2, BookStore_ID = 2 });
            modelBuilder.Entity<BookStore_Book_Model>().HasData(new BookStore_Book_Model { Book_ID = 2, BookStore_ID = 3 });

            //Book 3 and its stores
            modelBuilder.Entity<BookStore_Book_Model>().HasData(new BookStore_Book_Model { Book_ID = 3, BookStore_ID = 3 });
            modelBuilder.Entity<BookStore_Book_Model>().HasData(new BookStore_Book_Model { Book_ID = 3, BookStore_ID = 1 });

            //Book 4 and its stores
            modelBuilder.Entity<BookStore_Book_Model>().HasData(new BookStore_Book_Model { Book_ID = 4, BookStore_ID = 1 });
            modelBuilder.Entity<BookStore_Book_Model>().HasData(new BookStore_Book_Model { Book_ID = 4, BookStore_ID = 2 });
            modelBuilder.Entity<BookStore_Book_Model>().HasData(new BookStore_Book_Model { Book_ID = 4, BookStore_ID = 3 });

            //Book 5 and its stores
            modelBuilder.Entity<BookStore_Book_Model>().HasData(new BookStore_Book_Model { Book_ID = 5, BookStore_ID = 2 });

            //Book 5 and its stores
            modelBuilder.Entity<BookStore_Book_Model>().HasData(new BookStore_Book_Model { Book_ID = 6, BookStore_ID = 3 });




        }

    }
}

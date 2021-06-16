using KittyCat.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KittyCat.Controllers
{
    public class BreedController : Controller
    {
        private List<BreedModel> breeds = new List<BreedModel>()
            {
                new BreedModel {  id=1, name ="Siamese cat",
                    overview="One of the best-known cat breeds, the Siamese is curious, smart, vocal and demanding. If you want a cat who will converse with you all day long, the Siamese may be your perfect match. The Siamese weighs six to 10 pounds and has a distinctive coat with dark “points” on a light background",
                    image = "https://vetstreet.brightspotcdn.com/dims4/default/b73de6d/2147483647/thumbnail/645x380/quality/90/?url=https%3A%2F%2Fvetstreet-brightspot.s3.amazonaws.com%2Fe6%2F75%2F714c36604fc0aefcc5df187a06b9%2FSiamese-AP-U2BPOE-645sm3614.jpg",
                    personality = "Siamese are endlessly curious, but inclined to be smart and demanding. If you want a Siamese just for his looks, think again. This is a cat who has a passion for his people and will involve himself in everything they are doing. When they’re not around, he will entertain himself by turning on faucets, opening cabinets, seeking out new hideaways to frustrate anyone who might be searching for him, and watching television with clear interest. He may also be willing to walk on leash and play fetch with the same enthusiasm as a certain other four-legged animal to which he disdains being compared.",
                    grooming = "The short coat of the Siamese is easy to groom. Comb him weekly with a stainless steel comb. Trim the nails as needed, usually every 10 to 14 days. Cats can be prone to periodontal disease, so brush the teeth at home with a vet-approved pet toothpaste and schedule regular veterinary dental cleanings.",
                },
                new BreedModel { id =2, name = "Persian cat",
                    overview="The Persian is the glamor puss of the cat world. His beautiful, flowing coat, sweet face and calm personality have combined to make him the most popular cat breed. He is high maintenance and he has some health issues, but for many his looks and personality overcome those drawbacks." ,
                    image ="https://vetstreet.brightspotcdn.com/dims4/default/303f54d/2147483647/thumbnail/645x380/quality/90/?url=https%3A%2F%2Fvetstreet-brightspot.s3.amazonaws.com%2F29%2Fb6%2Ff4a864144d09974dfe5bf0513e20%2FPersian-AP-V8HE5B-645sm3614.jpg" ,
                    personality = "Persians are gentle, quiet cats who like a serene environment and people who treat them kindly. Unlike more athletic cats, they prefer lounging on a sofa to scaling the heights of your bookcase or fireplace mantel. Children are acceptable to the Persian as long as they are content to simply pet him and not drag him around or dress him up. On the other hand, the Persian may be a welcome guest at a little girl’s tea party and will bat decorously at a peacock feather before returning to pose beautifully on his sofa. In general, just make sure children treat this cat with the gentle respect he deserves.",
                    grooming = "There’s no getting around it: a Persian cat is high maintenance. The coat must be groomed daily with a stainless steel comb to remove mats, tangles and loose hair. Mats and tangles can be painful to a cat, and loose hair gets all over your clothes and furniture, so you can see the benefit to spending the time needed to care for the coat.",
                },

                new BreedModel {  id=3, name = "Bengal cat",
                    overview="If you love a cat with an exotic look but without the size and danger of a wild cat, the Bengal was developed with you in mind. Created by crossing small Asian Leopard Cats with domestic cats, this large-boned, shorthaired cat stands out for his spotted or marbled coat of many colors." ,
                    image = "https://vetstreet.brightspotcdn.com/dims4/default/3d0e85a/2147483647/thumbnail/645x380/quality/90/?url=https%3A%2F%2Fvetstreet-brightspot.s3.amazonaws.com%2Fee%2Fae%2F45110b914bfaa74c09c9533667a4%2FBengal-AP-1TJ0WG-645sm3614.jpg",
                    personality = "Bengals are a lot of fun to live with, but they’re definitely not the cat for everyone, or for first-time cat owners. Extremely intelligent, curious and active, they demand a lot of interaction and woe betide the owner who doesn’t provide it. If you won’t be home during the day to entertain your Bengal, plan to have two of them or don’t get one. When a Bengal gets bored, he is capable of taking things apart to see how they work and opening drawers and cabinets to see what interesting toys or food might be available for him.",
                    grooming = "Bengals have a short, luxurious, soft coat that is easy to care for with weekly brushing. He will love the attention, and if you brush him more often you will find fewer dust bunnies and hairballs around the house.The rest is basic care. Trim the nails as needed, usually weekly",
                },

                new BreedModel { id=4,  name = "Sphynx cat",
                    overview="The Sphynx seems like a contradiction: a hairless cat? But people who come to know him soon fall under the spell of this bald but beautiful feline. His warmth, humor and exotic appearance all combine to make him a favorite with cat lovers." ,
                    image = "https://vetstreet.brightspotcdn.com/dims4/default/69fe629/2147483647/thumbnail/645x380/quality/90/?url=https%3A%2F%2Fvetstreet-brightspot.s3.amazonaws.com%2F86%2F974690a33511e087a80050568d634f%2Ffile%2FSphynx-2-645mk062211.jpg",
                    personality = "People who love them say that living with a Sphynx is substantially different from having a “regular” cat. The Sphynx is snuggly and affectionate, always wanting to be close to you. Partly that’s because he’s seeking warmth, but he is an unusually friendly cat who loves attention and touch.",
                    grooming = "If you want a Sphynx because you think you won’t have to spend any time grooming him, you should probably reconsider. His body becomes oily and must be bathed anywhere from weekly to monthly to prevent clogged pores, not to mention oily spots on your furniture or clothing. Your Sphynx kitten will already have had some baths by the time you get him, but that doesn’t necessarily mean he will like being bathed. Make it a happy time, though, and he will probably come to love the attention.",
                },
            };
        public IActionResult Index()
        {
            ViewData["Breeds"] = breeds;
            return View();
        }
        public IActionResult Details(int Id = 1)
        {
            var breed = breeds.Find(match: model => model.id == Id);
            ViewData["Breed"] = breed;
            return View();
        }
    }
}

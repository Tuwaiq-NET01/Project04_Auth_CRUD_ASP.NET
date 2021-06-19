using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalProject.Migrations
{
    public partial class AddDataToMoviesAndTvShows : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Date", "Poster", "Rating", "Summary", "Title" },
                values: new object[,]
                {
                    { 1, "2021-05-26", "https://image.tmdb.org/t/p/w300/rTh4K5uw9HypmpGslcKd4QfHl93.jpg", 9, "In 1970s London amidst the punk rock revolution, a young grifter named Estella is determined to make a name for herself with her designs. She befriends a pair of young thieves who appreciate her appetite for mischief, and together they are able to build a life for themselves on the London streets. One day, Estella’s flair for fashion catches the eye of the Baroness von Hellman, a fashion legend who is devastatingly chic and terrifyingly haute. But their relationship sets in motion a course of events and revelations that will cause Estella to embrace her wicked side and become the raucous, fashionable and revenge-bent Cruella.", "Cruella" },
                    { 58, "2021-03-08", "https://image.tmdb.org/t/p/w300/jDwZavHo99JtGsCyRzp4epeeBHx.jpg", 7, "In the aftermath of the Fourth Impact, stranded without their Evangelions, Shinji, Asuka, and Rei search for refuge in the desolate red remains of Tokyo-3. But the danger to the world is far from over. A new impact is looming on the horizon—one that will prove to be the true end of Evangelion.", "Evangelion: 3.0+1.0 Thrice Upon a Time" },
                    { 57, "2019-10-02", "https://image.tmdb.org/t/p/w300/udDclJoHjfjb8Ekgsd4FDteOkCU.jpg", 8, "During the 1980s, a failed stand-up comedian is driven insane and turns to a life of crime and chaos in Gotham City while becoming an infamous psychopathic crime figure.", "Joker" },
                    { 56, "2021-02-24", "https://image.tmdb.org/t/p/w300/9kg73Mg8WJKlB9Y2SAJzeDKAnuB.jpg", 7, "Two unlikely companions embark on a perilous adventure through the badlands of an unexplored planet as they try to escape a dangerous and disorienting reality, where all inner thoughts are seen and heard by everyone.", "Chaos Walking" },
                    { 55, "2021-01-29", "https://image.tmdb.org/t/p/w300/dWSnsAGTfc8U27bWsy2RfwZs0Bs.jpg", 6, "When a prisoner transfer van is attacked, the cop in charge must fight those inside and outside while dealing with a silent foe: the icy temperatures.", "Below Zero" },
                    { 54, "2021-01-15", "https://image.tmdb.org/t/p/w300/6XYLiMxHAaCsoyrVo38LBWMw2p8.jpg", 6, "In the near future, a drone pilot is sent into a deadly militarized zone and must work with an android officer to locate a doomsday device.", "Outside the Wire" },
                    { 53, null, "https://image.tmdb.org/t/p/w300/2DyEk84XnbJEdPlGF43crxfdtHH.jpg", 0, "The penultimate installment of the Fast and Furious franchise.", "Fast & Furious 10" },
                    { 52, "2020-11-25", "https://image.tmdb.org/t/p/w300/tbVZ3Sq88dZaCANlUcewQuHQOaE.jpg", 8, "Searching for a safer habitat, the prehistoric Crood family discovers an idyllic, walled-in paradise that meets all of its needs. Unfortunately, they must also learn to live with the Bettermans -- a family that's a couple of steps above the Croods on the evolutionary ladder. As tensions between the new neighbors start to rise, a new threat soon propels both clans on an epic adventure that forces them to embrace their differences, draw strength from one another, and survive together.", "The Croods: A New Age" },
                    { 59, "2020-09-30", "https://image.tmdb.org/t/p/w300/mKvw1Ic9enfFlCPBNJGiejRPMUO.jpg", 6, "Covert security company Vanguard is the last hope of survival for an accountant after he is targeted by the world's deadliest mercenary organization.", "Vanguard" },
                    { 51, "2021-02-12", "https://image.tmdb.org/t/p/w300/keEnkeAvifw8NSEC4f6WsqeLJgF.jpg", 7, "When his car breaks down, a quiet loner agrees to clean an abandoned family fun center in exchange for repairs. He soon finds himself waging war against possessed animatronic mascots while trapped inside Willy's Wonderland.", "Willy's Wonderland" },
                    { 49, "2021-02-06", "https://image.tmdb.org/t/p/w300/6goDkAD6J3br81YMQf0Gat8Bqjy.jpg", 9, "3000 years after the boy-god Nezha conquers the Dragon King then disappears in mythological times, he returns as an ordinary man to find his own path to becoming a true hero.", "New Gods: Nezha Reborn" },
                    { 48, "2021-04-27", "https://image.tmdb.org/t/p/w300/e4REOC6CZW8J6FslA4nRvdQXFXR.jpg", 8, "While speeding off to help in an impromptu battle, The Flash blazes and rips through time, only to find himself dropped into the middle of World War II. It’s here that The Flash meets Wonder Woman and her top secret team, known as the Justice Society of America. Amidst the raging tides of war, gripping combat and the velocity of valor, The Flash must fight to return to his own timeline.", "Justice Society: World War II" },
                    { 47, "2020-09-26", "https://image.tmdb.org/t/p/w300/19kfvGktytDZInUmpv3WlaHoTxP.jpg", 8, "During a school field trip, Ladybug and Cat Noir meet the American superheroes, whom they have to save from an akumatised super-villain. They discover that Miraculous exist in the United States too.", "Miraculous World: New York, United HeroeZ" },
                    { 46, "2021-05-26", "https://image.tmdb.org/t/p/w300/vdMsMYfkHJ6mLht5QCg7Hl8hnEp.jpg", 6, "After witnessing a haunting in their hospital, two doctors become dangerously obsessed with obtaining scientific proof that ghosts exist.", "Ghost Lab" },
                    { 45, "2020-07-09", "https://image.tmdb.org/t/p/w300/95S6PinQIvVe4uJAd82a2iGZ0rA.jpg", 5, "An adventure-loving couple convince their friends to explore a remote, uncharted cave system in the forests of Northern Australia. With a tropical storm approaching, they abseil into the mouth of the cave, but when the caves start to flood, tensions rise as oxygen levels fall and the friends find themselves trapped. Unknown to them, the storm has also brought in a pack of dangerous and hungry crocodiles.", "Black Water: Abyss" },
                    { 44, "2021-06-03", "https://image.tmdb.org/t/p/w300/xq2pkQZV5Yt1METvy5S0QjmCpsn.jpg", 6, "The story of Dylan Pettersson, a 23-year-old girl from a small island in the Swedish archipelago with big dancing aspirations.", "Dancing Queens" },
                    { 43, "2020-12-25", "https://image.tmdb.org/t/p/w300/hm58Jw4Lw8OIeECIq5qyPYhAeRJ.jpg", 8, "Joe Gardner is a middle school teacher with a love for jazz music. After a successful gig at the Half Note Club, he suddenly gets into an accident that separates his soul from his body and is transported to the You Seminar, a center in which souls develop and gain passions before being transported to a newborn child. Joe must enlist help from the other souls-in-training, like 22, a soul who has spent eons in the You Seminar, in order to get back to Earth.", "Soul" },
                    { 50, "2021-05-19", "https://image.tmdb.org/t/p/w300/bOFaAXmWWXC3Rbv4u4uM9ZSzRXP.jpg", 8, "Dominic Toretto and his crew battle the most skilled assassin and high-performance driver they've ever encountered: his forsaken brother.", "F9" },
                    { 60, "2021-02-26", "https://image.tmdb.org/t/p/w300/pwDvkDyaHEU9V7cApQhbcSJMG1w.jpg", 8, "Cherry drifts from college dropout to army medic in Iraq - anchored only by his true love, Emily. But after returning from the war with PTSD, his life spirals into drugs and crime as he struggles to find his place in the world.", "Cherry" },
                    { 61, "2021-09-08", "https://image.tmdb.org/t/p/w300/niw2AKHz6XmwiRMLWaoyAOAti0G.jpg", 0, "Evan McCauley has skills he never learned and memories of places he has never visited. Self-medicated and on the brink of a mental breakdown, a secret group that call themselves “Infinites” come to his rescue, revealing that his memories are real.", "Infinite" },
                    { 62, "2021-06-03", "https://image.tmdb.org/t/p/w300/nc7szo7ChOknEk8qCkABJyNgl5y.jpg", 7, "Frederick Fitzell is living his best life—until he starts having horrific visions of Cindy, a girl who vanished in high school. After reaching out to old friends with whom he used to take a mystery drug called Mercury, Fredrick realizes the only way to stop the visions lies deep within his own memories, so he embarks on a terrifying mental odyssey to learn the truth.", "Flashback" },
                    { 79, "2020-04-12", "https://image.tmdb.org/t/p/w300/4VlXER3FImHeFuUjBShFamhIp9M.jpg", 8, "After the vicious slaughter of his family by stone-cold mercenary Sub-Zero, Hanzo Hasashi is exiled to the torturous Netherrealm. There, in exchange for his servitude to the sinister Quan Chi, he’s given a chance to avenge his family – and is resurrected as Scorpion, a lost soul bent on revenge. Back on Earthrealm, Lord Raiden gathers a team of elite warriors – Shaolin monk Liu Kang, Special Forces officer Sonya Blade and action star Johnny Cage – an unlikely band of heroes with one chance to save humanity. To do this, they must defeat Shang Tsung’s horde of Outworld gladiators and reign over the Mortal Kombat tournament.", "Mortal Kombat Legends: Scorpion's Revenge" },
                    { 78, "2021-04-03", "https://image.tmdb.org/t/p/w300/tmghT8HaddVIS9hEXIOI9GuDchi.jpg", 5, "A group of archaeology students awaken an ancient mummy. After being trapped in a time loop, the only way they can escape, is to defeat the mummy. As the body count rises, it seems the Mummy has to collect the souls of those who woke him to be able to walk the earth - for good.", "Rise of the Mummy" },
                    { 77, "2021-01-26", "https://image.tmdb.org/t/p/w300/4U1SBHmwHkNA0eHZ2n1CuiC1K1g.jpg", 6, "Jen and a group of friends set out to hike the Appalachian Trail. Despite warnings to stick to the trail, the hikers stray off course—and cross into land inhabited by The Foundation, a hidden community of mountain dwellers who use deadly means to protect their way of life.", "Wrong Turn" },
                    { 76, "2020-12-17", "https://image.tmdb.org/t/p/w300/13B6onhL6FzSN2KaNeQeMML05pS.jpg", 4, "A hardened mechanic must stay awake and maintain an interstellar ark fleeing the dying planet Earth with a few thousand lucky souls on board... the last of humanity. Unfortunately, humans are not the only passengers. A shapeshifting alien creature has taken residence, its only goal is to kill as many people as possible. The crew must think quickly to stop this menace before it destroys mankind.", "Breach" },
                    { 75, "2021-03-18", "https://image.tmdb.org/t/p/w300/4ZSzEDVdxWVMVO4oZDvoodQOEfr.jpg", 7, "The Secret Magic Control Agency sends its two best agents, Hansel and Gretel, to fight against the witch of the Gingerbread House.", "Secret Magic Control Agency" },
                    { 74, "2021-02-05", "https://image.tmdb.org/t/p/w300/p9YDHJKvUoi7v2SCd3vLGPae1Xp.jpg", 7, "When the crew of a space junk collector ship called The Victory discovers a humanoid robot named Dorothy that's known to be a weapon of mass destruction, they get involved in a risky business deal which puts their lives at stake.", "Space Sweepers" },
                    { 73, "2021-06-02", "https://image.tmdb.org/t/p/w300/ze1Sdb7WB64TBJhPqg8sJtwQtes.jpg", 5, "After a breakup, an influencer takes her friends on a free trip to Bahia's vibrant Carnival, where she learns life's not just about social media likes.", "Carnaval" },
                    { 72, "2020-10-25", "https://image.tmdb.org/t/p/w300/b1C0FuXp4wiPmHLVKq4kwtDMgK6.jpg", 7, "In late 1967, a young orphaned boy goes to live with his loving grandma in the rural Alabama town of Demopolis. As the boy and his grandmother encounter some deceptively glamorous but thoroughly diabolical witches, she wisely whisks him away to a seaside resort. Regrettably, they arrive at precisely the same time that the world's Grand High Witch has gathered.", "Roald Dahl's The Witches" },
                    { 71, "2020-02-05", "https://image.tmdb.org/t/p/w300/h4VB6m0RwcicVEZvzftYZyKXs6K.jpg", 7, "Harley Quinn joins forces with a singer, an assassin and a police detective to help a young girl who had a hit placed on her after she stole a rare diamond from a crime lord.", "Birds of Prey (and the Fantabulous Emancipation of One Harley Quinn)" },
                    { 70, "2019-10-02", "https://image.tmdb.org/t/p/w300/udDclJoHjfjb8Ekgsd4FDteOkCU.jpg", 8, "During the 1980s, a failed stand-up comedian is driven insane and turns to a life of crime and chaos in Gotham City while becoming an infamous psychopathic crime figure.", "Joker" },
                    { 69, "2021-04-08", "https://image.tmdb.org/t/p/w300/vX1XLbrHxpryX9EOWI3akbasz6c.jpg", 8, "Su, a woman whose friends are only men, finds herself forced to follow a series of absurd instructions to overcome the unexpected death of her fiancé.", "Instructions for Su" },
                    { 68, "2021-01-29", "https://image.tmdb.org/t/p/w300/dWSnsAGTfc8U27bWsy2RfwZs0Bs.jpg", 6, "When a prisoner transfer van is attacked, the cop in charge must fight those inside and outside while dealing with a silent foe: the icy temperatures.", "Below Zero" },
                    { 67, "2021-02-26", "https://image.tmdb.org/t/p/w300/pwDvkDyaHEU9V7cApQhbcSJMG1w.jpg", 8, "Cherry drifts from college dropout to army medic in Iraq - anchored only by his true love, Emily. But after returning from the war with PTSD, his life spirals into drugs and crime as he struggles to find his place in the world.", "Cherry" },
                    { 66, "2019-12-20", "https://image.tmdb.org/t/p/w300/zGVbrulkupqpbwgiNedkJPyQum4.jpg", 8, "Class 1-A visits Nabu Island where they finally get to do some real hero work. The place is so peaceful that it's more like a vacation … until they're attacked by a villain with an unfathomable Quirk! His power is eerily familiar, and it looks like Shigaraki had a hand in the plan. But with All Might retired and citizens' lives on the line, there's no time for questions. Deku and his friends are the next generation of heroes, and they're the island's only hope.", "My Hero Academia: Heroes Rising" },
                    { 65, "2020-07-02", "https://image.tmdb.org/t/p/w300/qzA87Wf4jo1h8JMk9GilyIYvwsA.jpg", 6, "A black ops assassin is forced to fight for her own survival after a job goes dangerously wrong.", "Ava" },
                    { 64, "2020-09-30", "https://image.tmdb.org/t/p/w300/mKvw1Ic9enfFlCPBNJGiejRPMUO.jpg", 6, "Covert security company Vanguard is the last hope of survival for an accountant after he is targeted by the world's deadliest mercenary organization.", "Vanguard" },
                    { 63, "2021-05-26", "https://image.tmdb.org/t/p/w300/vdMsMYfkHJ6mLht5QCg7Hl8hnEp.jpg", 6, "After witnessing a haunting in their hospital, two doctors become dangerously obsessed with obtaining scientific proof that ghosts exist.", "Ghost Lab" },
                    { 42, "2021-05-27", "https://image.tmdb.org/t/p/w300/bT3c4TSOP8vBmMoXZRDPTII6eDa.jpg", 8, "The cast of Friends reunites for a once-in-a-lifetime celebration of the hit series, an unforgettable evening filled with iconic memories, uncontrollable laughter, happy tears, and special guests.", "Friends: The Reunion" },
                    { 41, "2021-06-17", "https://image.tmdb.org/t/p/w300/7rhzEufovmmUqVjcbzMHTBQ2SCG.jpg", 8, "In a beautiful seaside town on the Italian Riviera, two young boys experience an unforgettable summer filled with gelato, pasta and endless scooter rides. But all the fun is threatened by a deeply-held secret: they are sea monsters from another world just below the water’s surface.", "Luca" },
                    { 80, "2020-10-25", "https://image.tmdb.org/t/p/w300/2W4ZvACURDyhiNnSIaFPHfNbny3.jpg", 6, "When a virus threatens to turn the now earth-dwelling friendly alien hybrids against humans, Captain Rose Corley must lead a team of elite mercenaries on a mission to the alien world in order to save what's left of humanity.", "Skylines" },
                    { 39, "2019-12-19", "https://image.tmdb.org/t/p/w300/arHW8z3uHVknHc24dvc1pQvxjw.jpg", 6, "A group of unlikely heroes from across the Korean peninsula try to save the day after a volcano erupts on the mythical and majestic Baekdu Mountain.", "Ashfall" }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Date", "Poster", "Rating", "Summary", "Title" },
                values: new object[,]
                {
                    { 17, "2021-03-18", "https://image.tmdb.org/t/p/w300/tnAuB8q5vv7Ax9UAEje5Xi4BXik.jpg", 8, "Determined to ensure Superman's ultimate sacrifice was not in vain, Bruce Wayne aligns forces with Diana Prince with plans to recruit a team of metahumans to protect the world from an approaching threat of catastrophic proportions.", "Zack Snyder's Justice League" },
                    { 16, "2021-03-26", "https://image.tmdb.org/t/p/w300/oBgWY00bEFeZ9N25wWVyuQddbAo.jpg", 8, "Hutch Mansell, a suburban dad, overlooked husband, nothing neighbor — a \"nobody.\" When two thieves break into his home one night, Hutch's unknown long-simmering rage is ignited and propels him on a brutal path that will uncover dark secrets he fought to leave behind.", "Nobody" },
                    { 15, "2021-05-14", "https://image.tmdb.org/t/p/w300/w6n1pu9thpCVHILejsuhKf3tNCV.jpg", 7, "Before he built a drug empire, Ferry Bouman returns to his hometown on a revenge mission that finds his loyalty tested — and a love that alters his life.", "Ferry" },
                    { 14, "2021-05-14", "https://image.tmdb.org/t/p/w300/m6bUeV4mczG3z2YXXr5XDKPsQzv.jpg", 7, "A special crimes investigator forms an unlikely bond with a serial killer to bring down a global child sex trafficking syndicate.", "I Am All Girls" },
                    { 13, "2021-05-12", "https://image.tmdb.org/t/p/w300/lcyKve7nXRFgRyms9M1bndNkKOx.jpg", 6, "Working in the shadow of an esteemed police veteran, brash Detective Ezekiel “Zeke” Banks and his rookie partner take charge of a grisly investigation into murders that are eerily reminiscent of the city’s gruesome past.  Unwittingly entrapped in a deepening mystery, Zeke finds himself at the center of the killer’s morbid game.", "Spiral: From the Book of Saw" },
                    { 12, "2021-04-30", "https://image.tmdb.org/t/p/w300/vXHzO26mJaOt4VO7ZFiM6No5ScT.jpg", 6, "A lonesome stranger with nerves of steel must track down and kill a rogue hitman to satisfy an outstanding debt. But the only information he's been given is a time and location where to find his quarry. No name. No description. Nothing.", "The Virtuoso" },
                    { 10, "2021-05-21", "https://image.tmdb.org/t/p/w300/4q2hz2m8hubgvijz8Ez0T2Os2Yv.jpg", 7, "Following the events at home, the Abbott family now face the terrors of the outside world. Forced to venture into the unknown, they realize that the creatures that hunt by sound are not the only threats that lurk beyond the sand path.", "A Quiet Place Part II" },
                    { 18, "2021-04-16", "https://image.tmdb.org/t/p/w300/AoWY1gkcNzabh229Icboa1Ff0BM.jpg", 6, "Victoria is a young mother trying to put her dark past as a Russian drug courier behind her, but retired cop Damon forces Victoria to do his bidding by holding her daughter hostage. Now, Victoria must use guns, guts and a motorcycle to take out a series of violent gangsters—or she may never see her child again.", "Vanquish" },
                    { 9, "2021-04-29", "https://image.tmdb.org/t/p/w300/rEm96ib0sPiZBADNKBHKBv5bve9.jpg", 7, "An elite Navy SEAL uncovers an international conspiracy while seeking justice for the murder of his pregnant wife.", "Tom Clancy's Without Remorse" },
                    { 7, "2021-05-14", "https://image.tmdb.org/t/p/w300/z8CExJekGrEThbpMXAmCFvvgoJR.jpg", 6, "Following a zombie outbreak in Las Vegas, a group of mercenaries take the ultimate gamble: venturing into the quarantine zone to pull off the greatest heist ever attempted.", "Army of the Dead" },
                    { 6, "2021-05-27", "https://image.tmdb.org/t/p/w300/ccsSqbpEqr2KK9eMvoeF8ERFCd5.jpg", 7, "Jack Halsey takes his wife, their adult kids, and a friend for a dream vacation in Kenya. But as they venture off alone into a wilderness park, their safari van is flipped over by an angry rhino, leaving them injured and desperate. Then, as two of them go in search of rescue, a bloody, vicious encounter with a leopard and a clan of hyenas incites a desperate fight for survival.", "Endangered Species" },
                    { 5, "2021-04-07", "https://image.tmdb.org/t/p/w300/nkayOAUBUu4mMvyNf9iHSUiPjF1.jpg", 8, "Washed-up MMA fighter Cole Young, unaware of his heritage, and hunted by Emperor Shang Tsung's best warrior, Sub-Zero, seeks out and trains with Earth's greatest champions as he prepares to stand against the enemies of Outworld in a high stakes battle for the universe.", "Mortal Kombat" },
                    { 4, "2021-03-31", "https://image.tmdb.org/t/p/w300/bShgiEQoPnWdw4LBrYT5u18JF34.jpg", 7, "Alice, a young hearing-impaired girl who, after a supposed visitation from the Virgin Mary, is inexplicably able to hear, speak and heal the sick. As word spreads and people from near and far flock to witness her miracles, a disgraced journalist hoping to revive his career visits the small New England town to investigate. When terrifying events begin to happen all around, he starts to question if these phenomena are the works of the Virgin Mary or something much more sinister.", "The Unholy" },
                    { 3, "2021-04-22", "https://image.tmdb.org/t/p/w300/M7SUK85sKjaStg4TKhlAVyGlz3.jpg", 8, "A cold and mysterious new security guard for a Los Angeles cash truck company surprises his co-workers when he unleashes precision skills during a heist. The crew is left wondering who he is and where he came from. Soon, the marksman's ultimate motive becomes clear as he takes dramatic and irrevocable steps to settle a score.", "Wrath of Man" },
                    { 2, "2021-05-25", "https://image.tmdb.org/t/p/w300/xbSuFiJbbBWCkyCCKIMfuDCA4yV.jpg", 8, "Paranormal investigators Ed and Lorraine Warren encounter what would become one of the most sensational cases from their files. The fight for the soul of a young boy takes them beyond anything they'd ever seen before, to mark the first time in U.S. history that a murder suspect would claim demonic possession as a defense.", "The Conjuring: The Devil Made Me Do It" },
                    { 40, "2021-05-04", "https://image.tmdb.org/t/p/w300/2xnf2ZaGXudvgBKPtVXMkNeooh1.jpg", 7, "In a daycare far, far away… but still in Springfield, Maggie is on an epic quest for her stolen pacifier. Her adventure brings her face-to-face with young Padawans, Sith Lords, familiar droids, Rebel scum, and an ultimate battle against the dark side, in this original short celebrating the Star Wars galaxy.", "Maggie Simpson in The Force Awakens from Its Nap" },
                    { 8, "2021-03-24", "https://image.tmdb.org/t/p/w300/pgqgaUx1cJb5oZQQ5v0tNARCeBp.jpg", 8, "In a time when monsters walk the Earth, humanity’s fight for its future sets Godzilla and Kong on a collision course that will see the two most powerful forces of nature on the planet collide in a spectacular battle for the ages.", "Godzilla vs. Kong" },
                    { 19, "2021-03-03", "https://image.tmdb.org/t/p/w300/lPsD10PP4rgUGiGR4CCXA6iY0QQ.jpg", 8, "Long ago, in the fantasy world of Kumandra, humans and dragons lived together in harmony. But when an evil force threatened the land, the dragons sacrificed themselves to save humanity. Now, 500 years later, that same evil has returned and it’s up to a lone warrior, Raya, to track down the legendary last dragon to restore the fractured land and its divided people.", "Raya and the Last Dragon" },
                    { 11, "2021-05-05", "https://image.tmdb.org/t/p/w300/xCEg6KowNISWvMh8GvPSxtdf9TO.jpg", 7, "A young boy finds himself pursued by two assassins in the Montana wilderness with a survival expert determined to protecting him - and a forest fire threatening to consume them all.", "Those Who Wish Me Dead" },
                    { 21, "2020-10-16", "https://image.tmdb.org/t/p/w300/h8Rb9gBr48ODIwYUttZNYeMWeUU.jpg", 8, "Tanjirō Kamado, joined with Inosuke Hashibira, a boy raised by boars who wears a boar's head, and Zenitsu Agatsuma, a scared boy who reveals his true power when he sleeps, boards the Infinity Train on a new mission with the Fire Hashira, Kyōjurō Rengoku, to defeat a demon who has been tormenting the people and killing the demon slayers who oppose it!", "Demon Slayer -Kimetsu no Yaiba- The Movie: Mugen Train" },
                    { 20, "2021-04-04", "https://image.tmdb.org/t/p/w300/msI5a9TPnepx47JUb2vl88hb80R.jpg", 8, "On school break, Marinette heads to Shanghai to meet Adrien. But after arriving, Marinette loses all her stuff, including the Miraculous that allows her to turn into Ladybug!", "Miraculous World: Shanghai – The Legend of Ladydragon" },
                    { 37, "2013-03-20", "https://image.tmdb.org/t/p/w300/wVYREutTvI2tmxr6ujrHT704wGF.jpg", 8, "Paranormal investigators Ed and Lorraine Warren work to help a family terrorized by a dark presence in their farmhouse. Forced to confront a powerful entity, the Warrens find themselves caught in the most terrifying case of their lives.", "The Conjuring" },
                    { 36, "2021-04-29", "https://image.tmdb.org/t/p/w300/xD9mc8JCVXA8T8u4Od7qOUBuGH4.jpg", 6, "In the 1930s, a young reverend and his family are forced to confront their worst fears when they discover their new home holds a horrifying secret.", "The Banishing" },
                    { 35, "2021-02-11", "https://image.tmdb.org/t/p/w300/8XZI9QZ7Pm3fVkigWJPbrXCMzjq.jpg", 7, "Tom the cat and Jerry the mouse get kicked out of their home and relocate to a fancy New York hotel, where a scrappy employee named Kayla will lose her job if she can’t evict Jerry before a high-class wedding at the hotel. Her solution? Hiring Tom to get rid of the pesky mouse.", "Tom & Jerry" },
                    { 34, "2020-12-03", "https://image.tmdb.org/t/p/w300/1UCOF11QCw8kcqvce8LKOO6pimh.jpg", 7, "A portal transports Cpt. Artemis and an elite unit of soldiers to a strange world where powerful monsters rule with deadly ferocity. Faced with relentless danger, the team encounters a mysterious hunter who may be their only hope to find a way home.", "Monster Hunter" },
                    { 33, "2021-02-11", "https://image.tmdb.org/t/p/w300/zAWaWUsVSMhZJmMVYj3WzwprQN7.jpg", 8, "While under the care of the Outer Sailor Guardians, Hotaru begins to age rapidly. Then, the time comes for all the Sailor Guardians to reunite!", "Pretty Guardian Sailor Moon Eternal The Movie Part 2" },
                    { 31, "2020-12-16", "https://image.tmdb.org/t/p/w300/8UlWHLMpgZm9bx6QYh0NFoq67TZ.jpg", 7, "A botched store robbery places Wonder Woman in a global battle against a powerful and mysterious ancient force that puts her powers in jeopardy.", "Wonder Woman 1984" },
                    { 30, "2021-03-05", "https://image.tmdb.org/t/p/w300/AmUGn1rJ9XDDP6DYn9OA2uV8MIg.jpg", 6, "Transferred home after a traumatizing combat mission, a highly trained French soldier uses her lethal skills to hunt down the man who hurt her sister.", "Sentinelle" },
                    { 32, "2016-05-13", "https://image.tmdb.org/t/p/w300/zEqyD0SBt6HL7W9JQoWwtd5Do1T.jpg", 7, "Lorraine and Ed Warren travel to north London to help a single mother raising four children alone in a house plagued by malicious spirits.", "The Conjuring 2" },
                    { 38, "2021-01-07", "https://image.tmdb.org/t/p/w300/tMS2qcbhbkFpcwLnbUE9o9IK4HH.jpg", 7, "When Maya, a headstrong little bee, and her best friend Willi, rescue an ant princess they find themselves in the middle of an epic bug battle that will take them to strange new worlds and test their friendship to its limits.", "Maya the Bee: The Golden Orb" },
                    { 28, "2021-04-30", "https://image.tmdb.org/t/p/w300/32vLDKSzcCMh55zqqaSqqUA8naz.jpg", 7, "Set before the events of ‘Soul’, 22 refuses to go to Earth, enlisting a gang of 5 new souls in attempt of rebellion. However, 22’s subversive plot leads to a surprising revelation about the meaning of life.", "22 vs. Earth" },
                    { 27, "2018-04-03", "https://image.tmdb.org/t/p/w300/nAU74GmpUk7t5iklEp3bufwDq4n.jpg", 7, "A family is forced to live in silence while hiding from creatures that hunt by sound.", "A Quiet Place" },
                    { 26, "2021-04-12", "https://image.tmdb.org/t/p/w300/nxxuWC32Y6TULj4VnVwMPUFLIpK.jpg", 8, "A former intelligence agent gets involved with the first human clone, Seo Bok, who others seek, causing trouble.", "Seobok" },
                    { 25, "2021-01-08", "https://image.tmdb.org/t/p/w300/y1Tk1LUwS3nRlugiXnag6Bu1ToG.jpg", 7, "Having just returned home, decorated U.S. Marine Captain Brad Paxton's wife, Kate, is kidnapped by a terrorist group while working in Morocco. He is forced back into action for a daring and deadly operation to save the woman he loves.", "Redemption Day" },
                    { 24, "2021-04-09", "https://image.tmdb.org/t/p/w300/3mKMWP5OokB7QpcOMA1yl8BXFAF.jpg", 6, "In a world where supervillains are commonplace, two estranged childhood best friends reunite after one devises a treatment that gives them powers to protect their city.", "Thunder Force" },
                    { 23, "2021-06-04", "https://image.tmdb.org/t/p/w300/cwUhVcDeMYYeu8fq5q1OPOoSbZ7.jpg", 7, "Two years after the murder of his son and father, a retired hitman sets in motion a carefully crafted revenge plan against the killer: his own brother.", "Xtreme" },
                    { 22, "2021-04-02", "https://image.tmdb.org/t/p/w300/dkokENeY5Ka30BFgWAqk14mbnGs.jpg", 8, "Drac tries out some new monster pets to help occupy Tinkles for playtime.", "Monster Pets: A Hotel Transylvania Short" },
                    { 29, "2021-01-15", "https://image.tmdb.org/t/p/w300/6vcDalR50RWa309vBH1NLmG2rjQ.jpg", 7, "Jim Hanson’s quiet life is suddenly disturbed by two people crossing the US/Mexico border – a woman and her young son – desperate to flee a Mexican cartel. After a shootout leaves the mother dead, Jim becomes the boy’s reluctant defender. He embraces his role as Miguel’s protector and will stop at nothing to get him to safety, as they go on the run from the relentless assassins.", "The Marksman" }
                });

            migrationBuilder.InsertData(
                table: "TvShows",
                columns: new[] { "Id", "Date", "Poster", "Rating", "Summary", "Title" },
                values: new object[,]
                {
                    { 52, "2020-06-17", "https://image.tmdb.org/t/p/w300/pcT1vivabBnBk0tZgVBO1I8aK75.jpg", 9, "Victor is a new student at Creekwood High School on his own journey of self-discovery, facing challenges at home, adjusting to a new city, and struggling with his sexual orientation. When it all seems too much, he reaches out to Simon to help him navigate the ups and downs of high school.", "Love, Victor" },
                    { 57, "1999-01-31", "https://image.tmdb.org/t/p/w300/eWWCRjBfLyePh2tfZdvNcIvKSJe.jpg", 7, "Sick, twisted, politically incorrect and Freakin' Sweet animated series featuring the adventures of the dysfunctional Griffin family. Bumbling Peter and long-suffering Lois have three kids. Stewie (a brilliant but sadistic baby bent on killing his mother and taking over the world), Meg (the oldest, and is the most unpopular girl in town) and Chris (the middle kid, he's not very bright but has a passion for movies). The final member of the family is Brian - a talking dog and much more than a pet, he keeps Stewie in check whilst sipping Martinis and sorting through his own life issues.", "Family Guy" },
                    { 56, "2014-09-22", "https://image.tmdb.org/t/p/w300/hzeirSF6bRjssDh5JFrm5WRwFLd.jpg", 8, "Based on a true story, Scorpion is a high-octane drama about eccentric genius Walter O’Brien and his team of brilliant misfits who comprise the last line of defense against complex, high-tech threats of the modern age. As Homeland Security’s new think tank, O’Brien’s “Scorpion” team includes Toby Curtis, an expert behaviorist who can read anyone; Happy Quinn, a mechanical prodigy; and Sylvester Dodd, a statistics guru.", "Scorpion" },
                    { 55, "2020-07-08", "https://image.tmdb.org/t/p/w300/nzBenFJ2D2MCWTwTt2uc4BGWLtA.jpg", 8, "Connecting all her hopes in her life to her education, Eda comes face to face with Serkan Bolat, who unknowingly cuts her scholarship abroad and caused her to remain a high school graduate. Serkan Bolat offers to give Eda her scholarship back if she pretends to be engaged to him for two months. Eda first rejects the offer due to her hatred for him, but when circumstances change, she has no choice but to accept the offer. While pretending to be engaged, Serkan and Eda begin to have a passionate, challenging relationship that will make you forget all they know right, because love is hard. And that's why it's amazing!!", "You Knock on My Door" }
                });

            migrationBuilder.InsertData(
                table: "TvShows",
                columns: new[] { "Id", "Date", "Poster", "Rating", "Summary", "Title" },
                values: new object[,]
                {
                    { 54, "2011-06-23", "https://image.tmdb.org/t/p/w300/vQiryp6LioFxQThywxbC6TuoDjy.jpg", 8, "While running from a drug deal gone bad, Mike Ross, a brilliant young college-dropout, slips into a job interview with one of New York City's best legal closers, Harvey Specter. Tired of cookie-cutter law school grads, Harvey takes a gamble by hiring Mike on the spot after he recognizes his raw talent and photographic memory.", "Suits" },
                    { 53, "2016-07-19", "https://image.tmdb.org/t/p/w300/7lBJ6lOS0uQqsH13U9iMTikawQS.jpg", 8, "A young woman born in a mafia-controlled town seeks revenge on those who wrongfully harmed and imprisoned her family.", "Sin senos sí hay paraíso" },
                    { 51, "2019-11-12", "https://image.tmdb.org/t/p/w300/sWgBv7LV2PRoQgkxwlibdGXKz1S.jpg", 8, "After the fall of the Galactic Empire, lawlessness has spread throughout the galaxy. A lone gunfighter makes his way through the outer reaches, earning his keep as a bounty hunter.", "The Mandalorian" },
                    { 42, "2020-09-18", "https://image.tmdb.org/t/p/w300/jWTDtbp2TnUGw1OJoDqq2O9IS0M.jpg", 8, "Six teens attending an adventure camp on the opposite side of Isla Nublar must band together to survive when dinosaurs wreak havoc on the island.", "Jurassic World: Camp Cretaceous" },
                    { 49, "1994-09-22", "https://image.tmdb.org/t/p/w300/f496cm9enuEsZkSPzCwnTESEK5s.jpg", 8, "The misadventures of a group of friends as they navigate the pitfalls of work, life and love in Manhattan.", "Friends" },
                    { 48, "2010-04-05", "https://image.tmdb.org/t/p/w300/qk3eQ8jW4opJ48gFWYUXWaMT4l.jpg", 8, "Hook up with Finn and Jake as they travel the Land of Ooo searching for adventure. But remember, adventure isn’t always easy. Sometimes you’ve got to battle fire gnomes that torture old ladies, save a smelly hot dog princess from the Ice King, and thaw out a bunch of frozen businessmen. What the cabbage?!", "Adventure Time" },
                    { 47, "2019-11-12", "https://image.tmdb.org/t/p/w300/9S3BS5oS9a8sNiTWuZi9aveE4bR.jpg", 8, "A group of East High students countdown to the opening night of their school’s first-ever production of “High School Musical.” Showmances blossom; friendships are tested while new ones are made; rivalries flare and lives are changed forever as these young people discover the transformative power that only a high school drama club can provide.", "High School Musical: The Musical: The Series" },
                    { 46, "2013-09-12", "https://image.tmdb.org/t/p/w300/6PX0r5TRRU5y0jZ70y1OtbLYmoD.jpg", 9, "A gangster family epic set in 1919 Birmingham, England and centered on a gang who sew razor blades in the peaks of their caps, and their fierce boss Tommy Shelby, who means to move up in the world.", "Peaky Blinders" },
                    { 45, "2001-10-16", "https://image.tmdb.org/t/p/w300/pUhJGETy2sec4vEkiqJ9eGeIywc.jpg", 8, "The origins of the world’s greatest hero–from Krypton refugee Kal-el’s arrival on Earth through his tumultuous teen years to Clark Kent’s final steps toward embracing his destiny as the Man of Steel.", "Smallville" },
                    { 44, "2013-04-15", "https://image.tmdb.org/t/p/w300/Ag7VUdnrRz5Qpq3Yn3E5OCvFnu0.jpg", 8, "Set in the 1990s, these are the life and times of Amado Carrillo Fuentes, a man who became the head of the Juárez cartel. Nicknamed “El Señor de los Cielos” (Lord of the Skies) because of the large fleet of airplanes he used to transport drugs, he was also known for washing more than $200 million through Colombia to finance his huge fleet. He is described as the most powerful drug trafficker of his time.", "The Lord of the Skies" },
                    { 43, "2020-12-06", "https://image.tmdb.org/t/p/w300/xWJZjIKPeEZhK3JRYKOe06yW6IU.jpg", 8, "New Orleans judge Michael Desiato is forced to confront his own deepest convictions when his son is involved in a hit and run that embroils an organized crime family.", "Your Honor" },
                    { 58, "2012-10-10", "https://image.tmdb.org/t/p/w300/6AccYL0eb7uzHn98IKaNjvJbyuA.jpg", 8, "An edge-of-your-seat view into the lives of everyday heroes committed to one of America's noblest professions. For the firefighters, rescue squad and paramedics of Chicago Firehouse 51, no occupation is more stressful or dangerous, yet so rewarding and exhilarating. These courageous men and women are among the elite who forge headfirst into danger when everyone else is running the other way and whose actions make the difference between life and death.", "Chicago Fire" },
                    { 50, "2019-07-25", "https://image.tmdb.org/t/p/w300/mY7SeH4HFFxW1hiI6cWuwCRKptN.jpg", 8, "A group of vigilantes known informally as “The Boys” set out to take down corrupt superheroes with no more than blue-collar grit and a willingness to fight dirty.", "The Boys" },
                    { 59, "2020-12-04", "https://image.tmdb.org/t/p/w300/mYsWyfiIMxx4HDm0Wck7oJ9ckez.jpg", 8, "As Mexican-American Tejano singer Selena comes of age and realizes her dreams, she and her family make tough choices to hold on to love and music.", "Selena: The Series" },
                    { 78, "2018-10-03", "https://image.tmdb.org/t/p/w300/A8NqOX6Tol9srq9pS740q2ktgzH.jpg", 7, "Isabel and Diego, two complete strangers, must assume the identity of a married couple in order to flee the state of Sonora.", "Falsa Identidad" },
                    { 61, "2008-09-23", "https://image.tmdb.org/t/p/w300/acYXu4KaDj1NIkMgObnhe4C4a0T.jpg", 8, "Patrick Jane, a former celebrity psychic medium, uses his razor sharp skills of observation and expertise at \"reading\" people to solve serious crimes with the California Bureau of Investigation.", "The Mentalist" },
                    { 41, "2005-09-13", "https://image.tmdb.org/t/p/w300/KoYWXbnYuS3b0GyQPkbuexlVK9.jpg", 8, "When they were boys, Sam and Dean Winchester lost their mother to a mysterious and demonic supernatural force. Subsequently, their father raised them to be soldiers. He taught them about the paranormal evil that lives in the dark corners and on the back roads of America ... and he taught them how to kill it. Now, the Winchester brothers crisscross the country in their '67 Chevy Impala, battling every kind of supernatural threat they encounter along the way. ", "Supernatural" },
                    { 77, "2015-10-26", "https://image.tmdb.org/t/p/w300/zsaiq8ZclPuneuN7loLEbsh1ANJ.jpg", 7, "Twenty-four-year-old Kara Zor-El, who was taken in by the Danvers family when she was 13 after being sent away from Krypton, must learn to embrace her powers after previously hiding them. The Danvers teach her to be careful with her powers, until she has to reveal them during an unexpected disaster, setting her on her journey of heroism.", "Supergirl" },
                    { 76, "2014-01-08", "https://image.tmdb.org/t/p/w300/OlPR1kctwXzSUJQkZINDDhNlHV.jpg", 8, "A riveting police drama about the men and women of the Chicago Police Department's District 21 who put it all on the line to serve and protect their community. District 21 is made up of two distinctly different groups: the uniformed cops who patrol the beat and go head-to-head with the city's street crimes and the Intelligence Unit that combats the city's major offenses - organized crime, drug trafficking, high profile murders and beyond.", "Chicago P.D." },
                    { 75, "2005-09-22", "https://image.tmdb.org/t/p/w300/7TCwgX7oQKxcWYEhSPRmaHe6ULN.jpg", 8, "An elite team of FBI profilers analyze the country's most twisted criminal minds, anticipating their next moves before they strike again. The Behavioral Analysis Unit's most experienced agent is David Rossi, a founding member of the BAU who returns to help the team solve new cases.", "Criminal Minds" },
                    { 74, "2018-03-22", "https://image.tmdb.org/t/p/w300/lcuCED5Ky2uM5VE6wILOwt5FEb0.jpg", 8, "A group of heroic firefighters at Seattle Fire Station 19—from captain to newest recruit—risk their lives and hearts both in the line of duty and off the clock. These brave men and women are like family, literally and figuratively, and together they put their own lives in jeopardy as first responders to save the lives of others.", "Station 19" },
                    { 73, "2016-07-15", "https://image.tmdb.org/t/p/w300/x2LSRK2Cm7MZhjluni1msVJ3wDF.jpg", 9, "When a young boy vanishes, a small town uncovers a mystery involving secret experiments, terrifying supernatural forces, and one strange little girl.", "Stranger Things" },
                    { 72, "2012-10-10", "https://image.tmdb.org/t/p/w300/gKG5QGz5Ngf8fgWpBsWtlg5L2SF.jpg", 7, "Spoiled billionaire playboy Oliver Queen is missing and presumed dead when his yacht is lost at sea. He returns five years later a changed man, determined to clean up the city as a hooded vigilante armed with a bow.", "Arrow" },
                    { 71, "1997-08-13", "https://image.tmdb.org/t/p/w300/iiCY2QIGSnmtVkIdjkKAfwDs0KF.jpg", 8, "Follows the misadventures of four irreverent grade-schoolers in the quiet, dysfunctional town of South Park, Colorado.", "South Park" },
                    { 70, "2016-01-21", "https://image.tmdb.org/t/p/w300/uzQpQGISbtxc047IOssFo5AiDwU.jpg", 7, "When heroes alone are not enough ... the world needs legends. Having seen the future, one he will desperately try to prevent from happening, time-traveling rogue Rip Hunter is tasked with assembling a disparate group of both heroes and villains to confront an unstoppable threat — one in which not only is the planet at stake, but all of time itself. Can this ragtag team defeat an immortal threat unlike anything they have ever known?", "DC's Legends of Tomorrow" },
                    { 69, "2019-10-18", "https://image.tmdb.org/t/p/w300/o1lAdiCYmCuDb25wyBCJQMeUhVA.jpg", 8, "The series revolves around the Derbez family on their trip to Morocco, the family is made up of Eugenio Derbez, the patriarch of the family, Alessandra Rosaldo, his wife, Aitana Derbez, their daughter, Vadhir and José Eduardo Derbez, their children, and Aislinn Derbez, his eldest daughter. , along with Mauricio Ochmann and his daughter Kailani.", "Traveling with the Derbez" },
                    { 68, "1989-04-26", "https://image.tmdb.org/t/p/w300/6VKOfL6ihwTiB5Vibq6QTfzhxA6.jpg", 8, "After learning that he is from another planet, a warrior named Goku and his friends are prompted to defend it from an onslaught of extraterrestrial enemies.", "Dragon Ball Z" },
                    { 67, "2021-01-08", "https://image.tmdb.org/t/p/w300/EpDuYIK81YtCUT3gH2JDpyj8Qk.jpg", 8, "Revisit the epic heroes, villains and moments from across the MCU in preparation for the stories still to come. Each dynamic segment feeds directly into the upcoming series — setting the stage for future events. This series weaves together the many threads that constitute the unparalleled Marvel Cinematic Universe.", "Marvel Studios: Legends" },
                    { 66, "2003-09-23", "https://image.tmdb.org/t/p/w300/fi8EvaWtL5CvoielOjjVvTr7ux3.jpg", 7, "From murder and espionage to terrorism and stolen submarines, a team of special agents investigates any crime that has a shred of evidence connected to Navy and Marine Corps personnel, regardless of rank or position.", "NCIS" },
                    { 65, "2015-10-19", "https://image.tmdb.org/t/p/w300/qxbW47zmgFyBVmZSIqD9NA1DEjT.jpg", 8, "Normal high school kids by day, protectors of Paris by night! Miraculous follows the heroic adventures of Marinette and Adrien as they transform into Ladybug and Cat Noir and set out to capture akumas, creatures responsible for turning the people of Paris into villains. But neither hero knows the other’s true identity – or that they’re classmates!", "Miraculous: Tales of Ladybug & Cat Noir" },
                    { 64, "2007-02-15", "https://image.tmdb.org/t/p/w300/zAYRe2bJxpWTVrwwmBc00VFkAf4.jpg", 9, "Naruto Shippuuden is the continuation of the original animated TV series Naruto.The story revolves around an older and slightly more matured Uzumaki Naruto and his quest to save his friend Uchiha Sasuke from the grips of the snake-like Shinobi, Orochimaru. After 2 and a half years Naruto finally returns to his village of Konoha, and sets about putting his ambitions to work, though it will not be easy, as He has amassed a few (more dangerous) enemies, in the likes of the shinobi organization; Akatsuki.", "Naruto Shippūden" },
                    { 63, "2005-09-13", "https://image.tmdb.org/t/p/w300/eyTu5c8LniVciRZIOSHTvvkkgJa.jpg", 8, "Dr. Temperance Brennan and her colleagues at the Jeffersonian's Medico-Legal Lab assist Special Agent Seeley Booth with murder investigations when the remains are so badly decomposed, burned or destroyed that the standard identification methods are useless.", "Bones" },
                    { 62, "2021-04-11", "https://image.tmdb.org/t/p/w300/qSEKyf0fWhrCEQ3LTwLqe41eSvR.jpg", 9, "Takemichi Hanagaki is a freelancer that’s reached the absolute pits of despair in his life. He finds out that the only girlfriend he ever had, in middle school, Hinata Tachibana, had been killed by the ruthless Tokyo Manji Gang. The day after hearing about her death, he’s standing on the station platform and ends up being pushed over onto the tracks by a herd of people. He closes his eyes thinking he’s about to die, but when he opens his eyes back up, he somehow had gone back in time 12 years. Now that he’s back living the best days of his life, Takemichi decides to get revenge on his life.", "Tokyo Revengers" },
                    { 60, "2008-01-20", "https://image.tmdb.org/t/p/w300/ggFHVNu6YYI5L9pCfOacjizRGt.jpg", 9, "When Walter White, a New Mexico chemistry teacher, is diagnosed with Stage III cancer and given a prognosis of only two years left to live. He becomes filled with a sense of fearlessness and an unrelenting desire to secure his family's financial future at any cost as he enters the dangerous world of drugs and crime.", "Breaking Bad" },
                    { 40, "2011-06-05", "https://image.tmdb.org/t/p/w300/vY2vfAskJTiWsQSv6bdbNCQhPLm.jpg", 9, "Scott McCall, a high school student living in the town of Beacon Hills has his life drastically changed when he's bitten by a werewolf, becoming one himself. He must henceforth learn to balance his problematic new identity with his day-to-day teenage life. The following characters are instrumental to his struggle: Stiles, his best friend; Allison, his love interest who comes from a family of werewolf hunters; and Derek, a mysterious werewolf with a dark past. Throughout the series, he strives to keep his loved ones safe while maintaining normal relationships with them.", "Teen Wolf" },
                    { 21, "2018-10-25", "https://image.tmdb.org/t/p/w300/qTZIgXrBKURBK1KrsT7fe3qwtl9.jpg", 9, "In a place where young witches, vampires, and werewolves are nurtured to be their best selves in spite of their worst impulses, Klaus Mikaelson’s daughter, 17-year-old Hope Mikaelson, Alaric Saltzman’s twins, Lizzie and Josie Saltzman, among others, come of age into heroes and villains at The Salvatore School for the Young and Gifted.", "Legacies" },
                    { 38, "2013-09-23", "https://image.tmdb.org/t/p/w300/htJzeRcYI2ewMm4PTrg98UMXShe.jpg", 7, "Raymond \"Red\" Reddington, one of the FBI's most wanted fugitives, surrenders in person at FBI Headquarters in Washington, D.C. He claims that he and the FBI have the same interests: bringing down dangerous criminals and terrorists. In the last two decades, he's made a list of criminals and terrorists that matter the most but the FBI cannot find because it does not know they exist. Reddington calls this \"The Blacklist\". Reddington will co-operate, but insists that he will speak only to Elizabeth Keen, a rookie FBI profiler.", "The Blacklist" },
                    { 15, "2021-05-04", "https://image.tmdb.org/t/p/w300/WjQmEWFrOf98nT5aEfUfVYz9N2.jpg", 9, "The 'Bad Batch' of elite and experimental clones make their way through an ever-changing galaxy in the immediate aftermath of the Clone Wars.", "The Bad Batch" },
                    { 14, "2021-03-26", "https://image.tmdb.org/t/p/w300/yDWJYRAwMNKbIYT8ZB33qy84uzO.jpg", 9, "Mark Grayson is a normal teenager except for the fact that his father is the most powerful superhero on the planet. Shortly after his seventeenth birthday, Mark begins to develop powers of his own and enters into his father’s tutelage.", "Invincible" },
                    { 13, "2021-03-24", "https://image.tmdb.org/t/p/w300/o7uk5ChRt3quPIv8PcvPfzyXdMw.jpg", 8, "Hell-bent on exacting revenge and proving he was framed for his sister's murder, Álex sets out to unearth much more than the crime's real culprit.", "Who Killed Sara?" },
                    { 12, "2017-01-26", "https://image.tmdb.org/t/p/w300/wRbjVBdDo5qHAEOVYoMWpM58FSA.jpg", 9, "Set in the present, the series offers a bold, subversive take on Archie, Betty, Veronica and their friends, exploring the surreality of small-town life, the darkness and weirdness bubbling beneath Riverdale’s wholesome facade.", "Riverdale" },
                    { 11, "2021-04-18", "https://image.tmdb.org/t/p/w300/78aK4Msbr22A5PGa6PZV0pAvdwf.jpg", 8, "A detective in a small Pennsylvania town investigates a local murder while trying to keep her life from falling apart.", "Mare of Easttown" }
                });

            migrationBuilder.InsertData(
                table: "TvShows",
                columns: new[] { "Id", "Date", "Poster", "Rating", "Summary", "Title" },
                values: new object[,]
                {
                    { 10, "2021-02-23", "https://image.tmdb.org/t/p/w300/vlv1gn98GqMnKHLSh0dNciqGfBl.jpg", 8, "After years of facing megalomaniacal supervillains, monsters wreaking havoc on Metropolis, and alien invaders intent on wiping out the human race, The Man of Steel aka Clark Kent and Lois Lane come face to face with one of their greatest challenges ever: dealing with all the stress, pressures and complexities that come with being working parents in today's society.", "Superman & Lois" },
                    { 9, "2005-03-27", "https://image.tmdb.org/t/p/w300/clnyhPqj1SNgpAdeSS6a6fwE6Bo.jpg", 8, "Follows the personal and professional lives of a group of doctors at Seattle’s Grey Sloan Memorial Hospital.", "Grey's Anatomy" },
                    { 16, "2015-08-23", "https://image.tmdb.org/t/p/w300/4UjiPdFKJGJYdxwRs2Rzg7EmWqr.jpg", 8, "What did the world look like as it was transforming into the horrifying apocalypse depicted in \"The Walking Dead\"? This spin-off set in Los Angeles, following new characters as they face the beginning of the end of the world, will answer that question.", "Fear the Walking Dead" },
                    { 8, "2021-01-08", "https://image.tmdb.org/t/p/w300/sgxawbFB5Vi5OkPWQLNfl3dvkNJ.jpg", 8, "Inspired by the adventures of Arsène Lupin, gentleman thief Assane Diop sets out to avenge his father for an injustice inflicted by a wealthy family.", "Lupin" },
                    { 6, "2017-09-25", "https://image.tmdb.org/t/p/w300/6tfT03sGp9k4c0J3dypjrI8TSAI.jpg", 9, "A young surgeon with Savant syndrome is recruited into the surgical unit of a prestigious hospital. The question will arise: can a person who doesn't have the ability to relate to people actually save their lives", "The Good Doctor" },
                    { 5, "2020-01-31", "https://image.tmdb.org/t/p/w300/xUtOM1QO4r8w8yeE00QvBdq58N5.jpg", 8, "A small Norwegian town experiencing warm winters and violent downpours seems to be headed for another Ragnarök -- unless someone intervenes in time.", "Ragnarok" },
                    { 4, "2014-10-07", "https://image.tmdb.org/t/p/w300/lJA2RCMfsWoskqlQhXPSLFQGXEJ.jpg", 8, "After a particle accelerator causes a freak storm, CSI Investigator Barry Allen is struck by lightning and falls into a coma. Months later he awakens with the power of super speed, granting him the ability to move through Central City like an unseen guardian angel. Though initially excited by his newfound powers, Barry is shocked to discover he is not the only \"meta-human\" who was created in the wake of the accelerator explosion -- and not everyone is using their new powers for good. Barry partners with S.T.A.R. Labs and dedicates his life to protect the innocent. For now, only a few close friends and associates know that Barry is literally the fastest man alive, but it won't be long before the world learns what Barry Allen has become...The Flash.", "The Flash" },
                    { 3, "2016-01-25", "https://image.tmdb.org/t/p/w300/4EYPN5mVIhKLfxGruy7Dy41dTVn.jpg", 8, "Bored and unhappy as the Lord of Hell, Lucifer Morningstar abandoned his throne and retired to Los Angeles, where he has teamed up with LAPD detective Chloe Decker to take down criminals. But the longer he's away from the underworld, the greater the threat that the worst of humanity could escape.", "Lucifer" },
                    { 2, "2021-06-04", "https://image.tmdb.org/t/p/w300/rgMfhcrVZjuy5b7Pn0KzCRCEnMX.jpg", 8, "On a perilous adventure across a post-apocalyptic world, a lovable boy who's half-human and half-deer searches for a new beginning with a gruff protector.", "Sweet Tooth" },
                    { 1, "2021-06-09", "https://image.tmdb.org/t/p/w300/rX1wQMTKFqF0gvZyS0DDQqgnQPB.jpg", 8, "After stealing the Tesseract during the events of “Avengers: Endgame,” an alternate version of Loki is brought to the mysterious Time Variance Authority, a bureaucratic organization that exists outside of time and space and monitors the timeline. They give Loki a choice: face being erased from existence due to being a “time variant”or help fix the timeline and stop a greater threat.", "Loki" },
                    { 79, "2010-09-06", "https://image.tmdb.org/t/p/w300/mS5SLxMYcKfUxA0utBSR5MOAWWr.jpg", 9, "Two bored groundskeepers, Mordecai (a six-foot-tall blue jay) and Rigby (a hyperactive raccoon) are best friends who spend their days trying to entertain themselves by any means necessary, much to the displeasure of their boss. Their everyday pursuits often lead to things spiraling out of control and into the surreal.", "Regular Show" },
                    { 7, "2021-03-19", "https://image.tmdb.org/t/p/w300/6kbAMLteGO8yyewYau6bJ683sw7.jpg", 8, "Following the events of “Avengers: Endgame”, the Falcon, Sam Wilson and the Winter Soldier, Bucky Barnes team up in a global adventure that tests their abilities, and their patience.", "The Falcon and the Winter Soldier" },
                    { 17, "2021-01-15", "https://image.tmdb.org/t/p/w300/glKDfE6btIRcVB5zrjspRIs4r52.jpg", 8, "Wanda Maximoff and Vision—two super-powered beings living idealized suburban lives—begin to suspect that everything is not as it seems.", "WandaVision" },
                    { 18, "2018-06-12", "https://image.tmdb.org/t/p/w300/fuVuDYrs8sxvEolnYr0wCSvtyTi.jpg", 8, "After spending seventeen years in prison unfairly, a talented songwriter seeks revenge on the men who sank her and killed her family.", "The Queen of Flow" },
                    { 19, "2011-04-17", "https://image.tmdb.org/t/p/w300/u3bZgnGQ9T01sWNhyveQz0wH0Hl.jpg", 8, "Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and icy horrors beyond.", "Game of Thrones" },
                    { 37, "2014-03-19", "https://image.tmdb.org/t/p/w300/wcaDIAG1QdXQLRaj4vC1EFdBT2.jpg", 8, "100 years in the future, when the Earth has been abandoned due to radioactivity, the last surviving humans live on an ark orbiting the planet — but the ark won't last forever. So the repressive regime picks 100 expendable juvenile delinquents to send down to Earth to see if the planet is still habitable.", "The 100" },
                    { 36, "2004-11-16", "https://image.tmdb.org/t/p/w300/lkvhReTBZ2Ksl0Dl5Oplsf6UYkF.jpg", 9, "Dr. Gregory House, a drug-addicted, unconventional, misanthropic medical genius, leads a team of diagnosticians at the fictional Princeton–Plainsboro Teaching Hospital in New Jersey.", "House" },
                    { 35, "2019-03-15", "https://image.tmdb.org/t/p/w300/asDqvkE66EegtKJJXIRhBJPxscr.jpg", 8, "Terrifying creatures, wicked surprises and dark comedy converge in this NSFW anthology of animated stories presented by Tim Miller and David Fincher.", "Love, Death & Robots" },
                    { 34, "2013-03-03", "https://image.tmdb.org/t/p/w300/bQLrHIRNEkE3PdIWQrZHynQZazu.jpg", 8, "The adventures of Ragnar Lothbrok, the greatest hero of his age. The series tells the sagas of Ragnar's band of Viking brothers and his family, as he rises to become King of the Viking tribes. As well as being a fearless warrior, Ragnar embodies the Norse traditions of devotion to the gods. Legend has it that he was a direct descendant of Odin, the god of war and warriors.", "Vikings" },
                    { 33, "2019-07-23", "https://image.tmdb.org/t/p/w300/oogunE22HDTcTxFakKQbwqfw1qo.jpg", 5, "Each hour-long film follows a different women as they experience “moments that are emotionally raw, thought-provoking and utterly personal”.", "I Am..." },
                    { 32, "2020-10-03", "https://image.tmdb.org/t/p/w300/g1rK2nRXSidcMwNliWDIroWWGTn.jpg", 8, "With his days numbered, high schooler Yuji decides to hunt down and consume the remaining 19 fingers of a deadly curse so it can die with him.", "Jujutsu Kaisen" },
                    { 31, "2002-10-03", "https://image.tmdb.org/t/p/w300/vauCEnR7CiyBDzRCeElKkCaXIYu.jpg", 8, "In another world, ninja are the ultimate power, and in the Village Hidden in the Leaves live the stealthiest ninja in the land. Twelve years earlier, the fearsome Nine-Tailed Fox terrorized the village and claimed many lives before it was subdued and its spirit sealed within the body of a baby boy. That boy, Naruto Uzumaki, has grown up to become a ninja-in-training who's more interested in pranks than in studying ninjutsu.. but Naruto is determined to become the greatest ninja ever!", "Naruto" },
                    { 30, "2013-12-02", "https://image.tmdb.org/t/p/w300/8kOWDBK6XlPUzckuHDo3wwVRFwt.jpg", 9, "Rick is a mentally-unbalanced but scientifically-gifted old man who has recently reconnected with his family. He spends most of his time involving his young grandson Morty in dangerous, outlandish adventures throughout space and alternate universes. Compounded with Morty's already unstable family life, these events cause Morty much distress at home and school.", "Rick and Morty" },
                    { 29, "2018-04-22", "https://image.tmdb.org/t/p/w300/34FaY8qpjBAVysSfrJ1l7nrAQaD.jpg", 8, "The series dramatizes the life story of Mexican superstar singer Luis Miguel, who has captivated audiences in Latin America and beyond for decades.", "Luis Miguel: The Series" },
                    { 28, "2016-09-23", "https://image.tmdb.org/t/p/w300/r8ODGmfNbZQlNhiJl2xQENE2jsk.jpg", 7, "Vanessa Helsing, the daughter of famous vampire hunter and Dracula nemesis Abraham Van Helsing is resurrected five years in the future to find out that vampires have taken over the world and that she possesses unique power over them. She is humanity’s last hope to lead an offensive to take back what has been lost.", "Van Helsing" },
                    { 27, "1989-12-17", "https://image.tmdb.org/t/p/w300/zLudbPueg8CxGhMS2tyDh3p0TdK.jpg", 8, "Set in Springfield, the average American town, the show focuses on the antics and everyday adventures of the Simpson family; Homer, Marge, Bart, Lisa and Maggie, as well as a virtual cast of thousands. Since the beginning, the series has been a pop culture icon, attracting hundreds of celebrities to guest star. The show has also made name for itself in its fearless satirical take on politics, media and American life in general.", "The Simpsons" },
                    { 26, "1999-09-20", "https://image.tmdb.org/t/p/w300/jDCgWVlejIo8sQYxw3Yf1cVQUIL.jpg", 8, "In the criminal justice system, sexually-based offenses are considered especially heinous. In New York City, the dedicated detectives who investigate these vicious felonies are members of an elite squad known as the Special Victims Unit. These are their stories.", "Law & Order: Special Victims Unit" },
                    { 25, "2009-09-10", "https://image.tmdb.org/t/p/w300/kLEha9zVVv8acGFKTX4gjvSR2Q0.jpg", 8, "The story of two vampire brothers obsessed with the same girl, who bears a striking resemblance to the beautiful but ruthless vampire they knew and loved in 1864.", "The Vampire Diaries" },
                    { 24, "2010-10-31", "https://image.tmdb.org/t/p/w300/rqeYMLryjcawh2JeRpCVUDXYM5b.jpg", 8, "Sheriff's deputy Rick Grimes awakens from a coma to find a post-apocalyptic world dominated by flesh-eating zombies. He sets out to find his family and encounters many other survivors along the way.", "The Walking Dead" },
                    { 23, "2021-05-07", "https://image.tmdb.org/t/p/w300/9yxep7oJdkj3Pla9TD9gKflRApY.jpg", 7, "As the world's first generation of superheroes (who received their powers in the 1930s) become the revered elder guard in the present, their superpowered children struggle to live up to the legendary feats of their parents.", "Jupiter's Legacy" },
                    { 22, "2017-04-26", "https://image.tmdb.org/t/p/w300/oIkxqt6ug5zT5ZSUUyc1Iqopf02.jpg", 8, "Set in a dystopian future, a woman is forced to live as a concubine under a fundamentalist theocratic dictatorship. A TV adaptation of Margaret Atwood's novel.", "The Handmaid's Tale" },
                    { 20, "2018-10-25", "https://image.tmdb.org/t/p/w300/qTZIgXrBKURBK1KrsT7fe3qwtl9.jpg", 9, "In a place where young witches, vampires, and werewolves are nurtured to be their best selves in spite of their worst impulses, Klaus Mikaelson’s daughter, 17-year-old Hope Mikaelson, Alaric Saltzman’s twins, Lizzie and Josie Saltzman, among others, come of age into heroes and villains at The Salvatore School for the Young and Gifted.", "Legacies" },
                    { 39, "2018-05-02", "https://image.tmdb.org/t/p/w300/4CkQvdUAtoLW3qkjWi7t1MTnW7R.jpg", 8, "This Karate Kid sequel series picks up 30 years after the events of the 1984 All Valley Karate Tournament and finds Johnny Lawrence on the hunt for redemption by reopening the infamous Cobra Kai karate dojo. This reignites his old rivalry with the successful Daniel LaRusso, who has been working to maintain the balance in his life without mentor Mr. Miyagi.", "Cobra Kai" },
                    { 80, "2018-07-01", "https://image.tmdb.org/t/p/w300/jYeTfpxS3IzgqKkYCjmdCKwq8PW.jpg", 8, "Trunks returns from the future to train with Goku and Vegeta. However, it disappears without warning. Then the mysterious Fu bursts in, telling them that Trunks has been imprisoned in the Prison Planet, a mysterious complex in an unknown place in the universes. The group seeks the dragon balls to free Trunks, but an endless battle awaits them! Will Goku and the others rescue Trunks and escape the Prison Planet?", "Super Dragon Ball Heroes" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "TvShows",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TvShows",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TvShows",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TvShows",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TvShows",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "TvShows",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "TvShows",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "TvShows",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "TvShows",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "TvShows",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "TvShows",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "TvShows",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "TvShows",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "TvShows",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "TvShows",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "TvShows",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "TvShows",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "TvShows",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "TvShows",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "TvShows",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "TvShows",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "TvShows",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "TvShows",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "TvShows",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "TvShows",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "TvShows",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "TvShows",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "TvShows",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "TvShows",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "TvShows",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "TvShows",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "TvShows",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "TvShows",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "TvShows",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "TvShows",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "TvShows",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "TvShows",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "TvShows",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "TvShows",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "TvShows",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "TvShows",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "TvShows",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "TvShows",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "TvShows",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "TvShows",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "TvShows",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "TvShows",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "TvShows",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "TvShows",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "TvShows",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "TvShows",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "TvShows",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "TvShows",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "TvShows",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "TvShows",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "TvShows",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "TvShows",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "TvShows",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "TvShows",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "TvShows",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "TvShows",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "TvShows",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "TvShows",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "TvShows",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "TvShows",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "TvShows",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "TvShows",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "TvShows",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "TvShows",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "TvShows",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "TvShows",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "TvShows",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "TvShows",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "TvShows",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "TvShows",
                keyColumn: "Id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "TvShows",
                keyColumn: "Id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "TvShows",
                keyColumn: "Id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "TvShows",
                keyColumn: "Id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "TvShows",
                keyColumn: "Id",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "TvShows",
                keyColumn: "Id",
                keyValue: 80);
        }
    }
}

using FreeRoamProject.Client.FREEROAM.Phone.Apps.BrowserData;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
namespace FreeRoamProject.Client.FREEROAM.Phone.WebBrowser.Model.Dynasty
{
    public class Apartment : PropertyBase
    {
        //TODO: GXT LAR_IRANK
        public string Label(int n)
        {
            return n switch
            {
                1 => "MP_PROP_1" /* GXT: Eclipse Towers, Apt 31 */,
                2 => "MP_PROP_2" /* GXT: Eclipse Towers, Apt 9 */,
                3 => "MP_PROP_3" /* GXT: Eclipse Towers, Apt 40 */,
                4 => "MP_PROP_4" /* GXT: Eclipse Towers, Apt 5 */,
                5 => "MP_PROP_5" /* GXT: 3 Alta St, Apt 10 */,
                6 => "MP_PROP_6" /* GXT: 3 Alta St, Apt 57 */,
                7 => "MP_PROP_7" /* GXT: Del Perro Heights, Apt 20 */,
                8 => "MP_PROP_8" /* GXT: 1162 Power St, Apt 3 */,
                9 => "MP_PROP_9" /* GXT: 0605 Spanish Ave, Apt 1 */,
                10 => "MP_PROP_10" /* GXT: 0604 Las Lagunas Blvd, Apt 4 */,
                11 => "MP_PROP_11" /* GXT: 0184 Milton Rd, Apt 13 */,
                12 => "MP_PROP_12" /* GXT: The Royale, Apt 19 */,
                13 => "MP_PROP_13" /* GXT: 0504 S Mo Milton Dr */,
                14 => "MP_PROP_14" /* GXT: 0115 Bay City Ave, Apt 45 */,
                15 => "MP_PROP_15" /* GXT: 0325 South Rockford Dr */,
                16 => "MP_PROP_16" /* GXT: Dream Tower, Apt 15 */,
                17 => "MP_PROP_17" /* GXT: 2143 Las Lagunas Blvd, Apt 9 */,
                18 => "MP_PROP_18" /* GXT: 1561 San Vitas St, Apt 2 */,
                19 => "MP_PROP_19" /* GXT: 0112 S Rockford Dr, Apt 13 */,
                20 => "MP_PROP_20" /* GXT: 2057 Vespucci Blvd, Apt 1 */,
                21 => "MP_PROP_21" /* GXT: 0069 Cougar Ave, Apt 19 */,
                22 => "MP_PROP_22" /* GXT: 1237 Prosperity St, Apt 21 */,
                23 => "MP_PROP_23" /* GXT: 1115 Blvd Del Perro, Apt 18 */,
                24 => "MP_PROP_24" /* GXT: 0120 Murrieta Heights */,
                25 => "MP_PROP_25" /* GXT: Unit 14 Popular St */,
                26 => "MP_PROP_26" /* GXT: Unit 2 Popular St */,
                27 => "MP_PROP_27" /* GXT: 331 Supply St */,
                28 => "MP_PROP_28" /* GXT: Unit 1 Olympic Fwy */,
                29 => "MP_PROP_29" /* GXT: 0754 Roy Lowenstein Blvd */,
                30 => "MP_PROP_30" /* GXT: 12 Little Bighorn Ave */,
                31 => "MP_PROP_31" /* GXT: Unit 124 Popular St */,
                32 => "MP_PROP_32" /* GXT: 0552 Roy Lowenstein Blvd */,
                33 => "MP_PROP_33" /* GXT: 0432 Davis Ave */,
                34 => "MP_PROP_34" /* GXT: Del Perro Heights, Apt 7 */,
                35 => "MP_PROP_35" /* GXT: Weazel Plaza, Apt 101 */,
                36 => "MP_PROP_36" /* GXT: Weazel Plaza, Apt 70 */,
                37 => "MP_PROP_37" /* GXT: Weazel Plaza, Apt 26 */,
                38 => "MP_PROP_38" /* GXT: 4 Integrity Way, Apt 30 */,
                39 => "MP_PROP_39" /* GXT: 4 Integrity Way, Apt 35 */,
                40 => "MP_PROP_40" /* GXT: Richards Majestic, Apt 4 */,
                41 => "MP_PROP_41" /* GXT: Richards Majestic, Apt 51 */,
                42 => "MP_PROP_42" /* GXT: Tinsel Towers, Apt 45 */,
                43 => "MP_PROP_43" /* GXT: Tinsel Towers, Apt 29 */,
                44 => "MP_PROP_44" /* GXT: 142 Paleto Blvd */,
                45 => "MP_PROP_45" /* GXT: 1 Strawberry Ave */,
                46 => "MP_PROP_46" /* GXT: 1932 Grapeseed Ave */,
                47 => "MP_PROP_48" /* GXT: 1920 Senora Way */,
                48 => "MP_PROP_49" /* GXT: 2000 Great Ocean Highway */,
                49 => "MP_PROP_50" /* GXT: 197 Route 68 */,
                50 => "MP_PROP_51" /* GXT: 870 Route 68 Approach */,
                51 => "MP_PROP_52" /* GXT: 1200 Route 68 */,
                52 => "MP_PROP_57" /* GXT: 8754 Route 68 */,
                53 => "MP_PROP_59" /* GXT: 1905 Davis Ave */,
                54 => "MP_PROP_60" /* GXT: 1623 South Shambles St */,
                55 => "MP_PROP_61" /* GXT: 4531 Dry Dock St */,
                56 => "MP_PROP_62" /* GXT: 1337 Exceptionalists Way */,
                57 => "MP_PROP_63" /* GXT: Unit 76 Greenwich Parkway */,
                58 => "MP_PROP_64" /* GXT: Garage Innocence Blvd */,
                59 => "MP_PROP_65" /* GXT: 634 Blvd Del Perro */,
                60 => "MP_PROP_66" /* GXT: 0897 Mirror Park Blvd */,
                61 => "MP_PROP_67" /* GXT: Eclipse Towers, Apt 3 */,
                62 => "MP_PROP_68" /* GXT: Del Perro Heights, Apt 4 */,
                63 => "MP_PROP_69" /* GXT: Richards Majestic, Apt 2 */,
                64 => "MP_PROP_70" /* GXT: Tinsel Towers, Apt 42 */,
                65 => "MP_PROP_71" /* GXT: 4 Integrity Way, Apt 28 */,
                66 => "MP_PROP_72" /* GXT: 4 Hangman Ave */,
                67 => "MP_PROP_73" /* GXT: 12 Sustancia Rd */,
                68 => "MP_PROP_74" /* GXT: 4584 Procopio Dr */,
                69 => "MP_PROP_75" /* GXT: 4401 Procopio Dr */,
                70 => "MP_PROP_76" /* GXT: 0232 Paleto Blvd */,
                71 => "MP_PROP_77" /* GXT: 140 Zancudo Ave */,
                72 => "MP_PROP_78" /* GXT: 1893 Grapeseed Ave */,
                83 => "MP_PROP_79" /* GXT: Eclipse Towers, Penthouse Suite 1 */,
                84 => "MP_PROP_80" /* GXT: Eclipse Towers, Penthouse Suite 2 */,
                85 => "MP_PROP_81" /* GXT: Eclipse Towers, Penthouse Suite 3 */,
                73 => "MP_PROP_83" /* GXT: 3655 Wild Oats Drive */,
                74 => "MP_PROP_84" /* GXT: 2044 North Conker Avenue */,
                75 => "MP_PROP_85" /* GXT: 2868 Hillcrest Avenue */,
                76 => "MP_PROP_86" /* GXT: 2862 Hillcrest Avenue */,
                77 => "MP_PROP_87" /* GXT: 3677 Whispymound Drive */,
                78 => "MP_PROP_89" /* GXT: 2117 Milton Road */,
                79 => "MP_PROP_90" /* GXT: 2866 Hillcrest Avenue */,
                80 => "MP_PROP_92" /* GXT: 2874 Hillcrest Avenue */,
                81 => "MP_PROP_94" /* GXT: 2113 Mad Wayne Thunder Drive */,
                82 => "MP_PROP_95" /* GXT: 2045 North Conker Avenue */,
                _ => "",
            };
        }
        public string TXD(int n)//Position - 0x267B64
        {
            return n switch
            {
                1 => "DYN_MP_1",
                2 => "DYN_MP_2",
                3 => "DYN_MP_3",
                4 => "DYN_MP_4",
                5 => "DYN_MP_5",
                6 => "DYN_MP_6",
                7 => "DYN_MP_7",
                8 => "DYN_MP_8",
                9 => "DYN_MP_9",
                10 => "DYN_MP_10",
                11 => "DYN_MP_11",
                12 => "DYN_MP_12",
                13 => "DYN_MP_13",
                14 => "DYN_MP_14",
                15 => "DYN_MP_15",
                16 => "DYN_MP_16",
                17 => "DYN_MP_17",
                18 => "DYN_MP_18",
                19 => "DYN_MP_19",
                20 => "DYN_MP_20",
                21 => "DYN_MP_21",
                22 => "DYN_MP_22",
                23 => "DYN_MP_23",
                24 => "DYN_MP_24",
                25 => "DYN_MP_25",
                26 => "DYN_MP_26",
                27 => "DYN_MP_27",
                28 => "DYN_MP_28",
                29 => "DYN_MP_29",
                30 => "DYN_MP_30",
                31 => "DYN_MP_31",
                32 => "DYN_MP_32",
                33 => "DYN_MP_33",
                34 => "DYN_MP_34",
                35 => "DYN_MP_35",
                36 => "DYN_MP_36",
                37 => "DYN_MP_37",
                38 => "DYN_MP_38",
                39 => "DYN_MP_39",
                40 => "DYN_MP_40",
                41 => "DYN_MP_41",
                42 => "DYN_MP_42",
                43 => "DYN_MP_43",
                44 => "DYN_MP_44",
                45 => "DYN_MP_45",
                46 => "DYN_MP_46",
                47 => "DYN_MP_48",
                48 => "DYN_MP_49",
                49 => "DYN_MP_50",
                50 => "DYN_MP_51",
                51 => "DYN_MP_52",
                52 => "DYN_MP_57",
                53 => "DYN_MP_59",
                54 => "DYN_MP_60",
                55 => "DYN_MP_61",
                56 => "DYN_MP_62",
                57 => "DYN_MP_63",
                58 => "DYN_MP_64",
                59 => "DYN_MP_65",
                60 => "DYN_MP_66",
                61 => "DYN_MP_1",
                62 => "DYN_MP_7",
                63 => "DYN_MP_40",
                64 => "DYN_MP_42",
                65 => "DYN_MP_38",
                66 => "DYN_MP_72",
                67 => "DYN_MP_73",
                68 => "DYN_MP_74",
                69 => "DYN_MP_75",
                70 => "DYN_MP_76",
                71 => "DYN_MP_77",
                72 => "DYN_MP_78",
                73 => "DYN_MP_80",
                74 => "DYN_MP_81",
                75 => "DYN_MP_82",
                76 => "DYN_MP_83",
                77 => "DYN_MP_84",
                78 => "DYN_MP_85",
                79 => "DYN_MP_86",
                80 => "DYN_MP_87",
                81 => "DYN_MP_89",
                82 => "DYN_MP_90",
                83 => "DYN_MP_91",
                84 => "DYN_MP_92",
                85 => "DYN_MP_93",
                _ => "",
            };
        }
        public string Description(int n)
        {
            return n switch
            {
                1 => "MP_PROP_1DES" /* GXT: This luxury triplex is move-in ready! The previous owner was so rich he just left all his furniture. Just bring yourself and be ready for lots of new superficial friends when people find out you live on Eclipse Boulevard in Rockford Hills. Includes 10-car garage. */,
                2 => "MP_PROP_2DES" /* GXT: A massive, furnished, luxury triplex at this price? You've gotta love a bargain like this! Snap it up now before President Lawton loses the next election and they tax the hell out of you. Includes 10-car garage. */,
                3 => "MP_PROP_3DES" /* GXT: Eclipse Towers on Eclipse Boulevard... this is the best address in Rockford Hills! Stand at your floor-to-ceiling windows, take in the spectacular panoramic views, pour yourself a drink and toast how amazing your life is while you look down on everybody else. Includes 10-car garage. */,
                4 => "MP_PROP_4DES" /* GXT: Upper class living at middle class prices! Are you a single-digit millionaire who wants to live like a double-digit millionaire? You'll never find a better deal on a luxury condo in Rockford Hills than this again. Act now, it won't last! Includes 10-car garage. */,
                5 => "MP_PROP_5DES" /* GXT: With its own Bean Machine outlet on the ground floor and a short commute to the financial center, this luxury condo on Alta Street in Downtown Los Santos is the perfect pad for the banker who never sleeps because he's having too much fun gambling with other people's money. Includes 10-car garage. */,
                6 => "MP_PROP_6DES" /* GXT: Situated at the epicenter of the Los Santos financial, business and high-end shopping districts, you'll never have to see a poor person again at this luxury condo on Alta Street if you don't want to. Everything you need is right on your doorstep. Includes 10-car garage. */,
                7 => "MP_PROP_7DES" /* GXT: This luxury condo on Marathon Avenue and Prosperity Street, in one of the most stylish apartment buildings in hip Del Perro, directly opposite the Bahama Mamas nightclub for the perfect release at the end of a hard day's work. Includes 10-car garage. */,
                8 => "MP_PROP_8DES" /* GXT: Located steps away from a skate park, this cute-as-a-button one-bedroom in Hawick is perfect for families with teenage children or tragic 30-something hipsters with fixies. Includes 6-car garage. */,
                9 => "MP_PROP_9DES" /* GXT: This newly-renovated one-bedroom in Downtown Vinewood is a STEAL!~n~Hurry this one won't last! It did last!~n~$10,000 price reduction!~n~Crazy value!~n~Move NOW the price is right!~n~Everything's negotiable. Motivated seller.~n~Reduced again for quick sale!~n~WILL SOMEONE JUST BUY THIS ALREADY??? Includes 6-car garage. */,
                10 => "MP_PROP_10DES" /* GXT: This building has seen better days - the closest thing to a doorman is a homeless guy you sometimes have to step over to get into the lobby at night - but how else are you going to find a Vinewood apartment in your price range? Hope you like the smell of urine.~n~Includes 6-car garage. */,
                11 => "MP_PROP_11DES" /* GXT: Cozy one-bedroom in a cute West Vinewood apartment block! You'll only share the building with a few other units, meaning fewer neighbors for you to grow to despise. Includes 6-car garage. */,
                12 => "MP_PROP_12DES" /* GXT: The Royale apartment building in West Vinewood might not look regal on the outside but you'll live like a prince on the inside! PS Princes are douches.~n~Includes 6-car garage. */,
                13 => "MP_PROP_13DES" /* GXT: This modern, renovated one-bedroom is in a well-maintained building in a great West Vinewood location. Buy now at the bottom of the market! Property values can't go any lower! We're absolutely sure this time! Includes 6-car garage. */,
                14 => "MP_PROP_14DES" /* GXT: Hello, sailor! This renovated, fully-furnished apartment is right on the waterfront in Puerto Del Sol. Perfect for picking up other sailors.~n~Includes 6-car garage. */,
                15 => "MP_PROP_15DES" /* GXT: Location is in the eye of the beholder! Some might call this a busy traffic junction, we call it a Commuter's Dream! Some might call this Little Seoul, we call it Vespucci so we can up the price!~n~Includes 6-car garage. */,
                16 => "MP_PROP_16DES" /* GXT: Join the other creative types flocking to this neighborhood. With easy access to both a movie theater and a church, this apartment in Dream Tower is perfect for lovers of fiction.~n~Includes 6-car garage. */,
                17 => "MP_PROP_17DES" /* GXT: What this Hawick apartment lacks in space and all-round condition, it makes up for in proximity to the local liquor store. Drown in debt and your sorrows.~n~Includes 2-car garage. */,
                18 => "MP_PROP_18DES" /* GXT: Original features! This cozy apartment in West Vinewood had only one owner, who didn't update a single thing since he moved in there 40 years ago and then passed away – it was days before anyone noticed. Includes 2-car garage. */,
                19 => "MP_PROP_19DES" /* GXT: This compact apartment in a 2-story apartment building has been meticulously maintained in its original condition! Semi-partial ocean view! Includes 2-car garage. */,
                20 => "MP_PROP_20DES" /* GXT: The apartment building has seen better days but this affordable unit still has a Little Soul and a Lot of Potential! Bring your imagination! And an exterminator.~n~Includes 2-car garage. */,
                21 => "MP_PROP_21DES" /* GXT: This fixer-upper offers stunning views of the cemetery to at once remind you of your mortality and motivate you to get your act together and buy a better apartment one day.~n~Includes 2-car garage. */,
                22 => "MP_PROP_22DES" /* GXT: With both Wigwam and Up-n-Atom right on your doorstep, burger enthusiasts will be spoiled for choice at this apartment located in Del Perro or Morningwood, depending on which side of the building you stand. Includes 2-car garage. */,
                23 => "MP_PROP_23DES" /* GXT: With a funky retro décor and carpeted throughout, you can literally smell the history in this Del Perro apartment that features an almost unobstructed ocean view for an almost unbeatable price. Includes 2-car garage. */,
                24 => "MP_PROP_24DES" /* GXT: 10-Car Garage - With good access to the major roadways in and out of Los Santos, this spacious garage is perfect for the man or woman who might need to leave town in a hurry. Or is obsessed with cars. */,
                25 => "MP_PROP_25DES" /* GXT: 6-Car Garage - If you're an individual who likes to keep their business private, look no further than this secluded garage in East Los Santos. */,
                26 => "MP_PROP_26DES" /* GXT: 10-Car Garage - Spacious garage in prime East Los Santos. Panoramic views of urban blight, walking distance to gang members. */,
                27 => "MP_PROP_27DES" /* GXT: 10-Car Garage - Newly renovated garage with excellent square footage and direct road access. What better place to keep brand-new vehicles than the neighborhood with the highest crime rate in Los Santos? */,
                28 => "MP_PROP_28DES" /* GXT: 6-Car Garage - A good-sized garage in a quiet location within walking distance of the train for those days when you feel extra guilty about your 6-car carbon footprint. */,
                29 => "MP_PROP_29DES" /* GXT: 2-Car Garage - Located just a few brain-melting steps away from an electrical substation, you'll never have to worry losing power or reaching old age again at this garage in East Los Santos. */,
                30 => "MP_PROP_30DES" /* GXT: 2-Car Garage - Affluent on the inside, effluent on the outside! This garage offers panoramic views of the Los Santos waterways. */,
                31 => "MP_PROP_31DES" /* GXT: 2-Car Garage - Calling all bargain hunters! In today's economy, it's all about desirable properties in undesirable areas. East Los Santos? We prefer to call it 'South of Vinewood'! Plus if the economy keeps tanking, you can go live in it! */,
                32 => "MP_PROP_32DES" /* GXT: 6-Car Garage - This garage is in a killer area... literally! Be first to gentrify this neighborhood! In 20 years, it will be the next big thing! */,
                33 => "MP_PROP_33DES" /* GXT: 6-Car Garage - High standards in real estate, low standards in women? End the day with your own oil change at this garage located across from a strip club! */,
                34 => "MP_PROP_34DES" /* GXT: Luxury Del Perro Heights apartment complex! For all you voyeurs out there! This spectacular condo is one of the lower units so might not boast the best views, but all the buildings around you will have a direct eyeline into your awesome life 24/7. Includes 10-car garage. */,
                35 => "MP_PROP_35DES" /* GXT: Calling all actors! This is your chance to live on sought-after Movie Star Way in prime Rockford Hills directly opposite the legendary Richard Majestic film studios. Stagger out of your front door right onto set! Includes 10-car garage. */,
                36 => "MP_PROP_36DES" /* GXT: Movie Star Way! Don't miss this opportunity to live in one of the most exclusive apartment complexes in Rockford Hills. Even the janitor earns six figures in this building.~n~Includes 10-car garage. */,
                37 => "MP_PROP_37DES" /* GXT: This spectacular condo on Movie Star Way in prime Rockford Hills is move-in ready! Don't worry if you're a rich Los Santos philistine with no taste - it's all been picked out for you. All furniture, appliances, fixtures and art included.~n~Includes 10-car garage. */,
                38 => "MP_PROP_38DES" /* GXT: No dropped calls here! This luxury condo is located in the same building as Tinkle Mobile's headquarters in the new real estate hotspot of Downtown Los Santos. This is such an up-and-coming neighborhood, you can literally see the construction from your window!~n~Includes 10-car garage. */,
                39 => "MP_PROP_39DES" /* GXT: This beautiful Downtown triplex apartment has spectacular views of Los Santos and the iconic Vinewood Sign in the distance. Watch all the people chasing the dream while you live it! Includes 10-car garage. */,
                40 => "MP_PROP_40DES" /* GXT: This breathtaking luxury condo on Movie Star Way in Rockford Hills is a stone's throw from Richards Majestic Movie Studios, AKAN Records and a Sperm Donor Clinic. The ultimate trifecta of dying industries! Includes 10-car garage. */,
                41 => "MP_PROP_41DES" /* GXT: A luxury condo on Movie Star Way in Rockford Hills? This is one of the trendiest addresses in Los Santos! Imagine if all your neighbors were hedge fund managers and celebrities? Come on, live the dream. Includes 10-car garage. */,
                42 => "MP_PROP_42DES" /* GXT: Your split personality will be right at home in this retro-slash-ultramodern apartment building on Boulevard Del Perro. Go mad in style. Includes 10-car garage. */,
                43 => "MP_PROP_43DES" /* GXT: Parquet flooring, granite counter tops, floating fireplace, bland modern art, walk-in closet, towel warmers, leather headboard, man cave...this luxury condo in Tinsel Towers on Boulevard Del Perro checks all the boxes on the new-money millionaire tick list.~n~Includes 10-car garage. */,
                44 => "MP_PROP_44DES" /* GXT: 2-Car Garage - Annexed to a gas station and within easy distance of a number of cheap motels, this garage on Paleto Blvd in Paleto Bay has all you need for the perfect escape from the city. */,
                45 => "MP_PROP_45DES" /* GXT: 2-Car Garage - This garage near Paleto Blvd in Paleto Bay has seen better days but there's a barber's, a tattoo parlor and a Cluckin' Bell factory on your doorstep...so what more do you need? */,
                46 => "MP_PROP_46DES" /* GXT: 2-Car Garage - The town of Grapeseed offer a unique blend of heavy industry and genetically-modified farming that explains why everyone born there in the last 20 years looks so funny. This small garage on Grapeseed Avenue needs some TLC but is priced to sell. */,
                47 => "MP_PROP_48DES" /* GXT: 2-Car Garage - This garage is situated on the site of Ron Alternates on N. Senora Way. What better way to feel better about your carbon footprint than by storing your gas-guzzlers inside a wind farm? */,
                48 => "MP_PROP_49DES" /* GXT: 2-Car Garage - Across from the beach, ocean views, steps from a delicious seafood restaurant, this property on Great Ocean Highway in North Chumash is in an unbeatable location! The catch? It's a garage... */,
                49 => "MP_PROP_50DES" /* GXT: 2-Car Garage - Small one-door garage for sale on Route 68 on Harmony. With a rundown general store, a local arm-wrestling haunt and a seedy motel all nearby, park up and live the dream! */,
                50 => "MP_PROP_51DES" /* GXT: 6-Car Garage - Garage in need of some TLC for sale on Senora Rd in the Grand Senora Desert. Nothing of great note in the surrounding area. It's a garage. In a desert. */,
                51 => "MP_PROP_52DES" /* GXT: 2-Car Garage - Steps from a liquor store, a Dollar Pills pharmacy, a Suburban store, and an Animal Ark pet store, this garage on Route 68 in Harmony is a hipster's dream. Booze, cigarettes, faux-vintage clothing and organic dog food in one! */,
                52 => "MP_PROP_57DES" /* GXT: 6-Car Garage - Located behind an Ammu-Nation store and near to the Fort Zancudo Military Base, you won't have to worry about security at this garage on Route 68. */,
                53 => "MP_PROP_59DES" /* GXT: 6-Car Garage - Calling all Los Santos Panic fans! This garage on Crusade Road is in a prime location just down the road from the Maze Bank Arena! */,
                54 => "MP_PROP_60DES" /* GXT: 10-Car Garage - Are you in need of a low-profile lock-up where people won't ask too many questions? Look no further than this garage on South Shambles in Cypress Flats. */,
                55 => "MP_PROP_61DES" /* GXT: 6-Car Garage - If you're looking for a desolate, industrial lock-up far away from prying eyes, this garage on Dry Dock St in Cypress Flats is the one for you! */,
                56 => "MP_PROP_62DES" /* GXT: 10-Car Garage - Garage for sale on Exceptionalists Way. Why would you need a spacious, anonymous, non-descript lock-up with lots of space for storage close to the airport? We won't ask if you don't tell. */,
                57 => "MP_PROP_63DES" /* GXT: 10-Car Garage - In a prime location near Greenwich parkway in Los Santos International Airport, next door to Bilgeco Shipping services, this garage is perfect for a man or woman who might need to transport something in a hurry or get out of a town in a hurry. */,
                58 => "MP_PROP_64DES" /* GXT: 2-Car Garage - Garage for sale on Innocence Blvd in La Puerta. How can there be this many garages for sale in Los Santos? We're as puzzled by this real estate boom as you are. */,
                59 => "MP_PROP_65DES" /* GXT: 2-Car Garage - If you're feeling the pinch of the economic downturn but desperate for a prime Rockford Hills address, this garage on Boulevard Del Perro might be the perfect compromise! */,
                60 => "MP_PROP_66DES" /* GXT: 2-Car Garage - Garage for sale on Mirror Park Blvd in East Vinewood. If you're looking for a garage in Los Santos, don't delay! It's an incredible buyer's market right now. They're everywhere! */,
                61 => "MP_PROP_67DES" /* GXT: Part of The High Life Update. Perfectly proportioned, beautifully presented lateral living opportunity on exquisite Eclipse Blvd. This apartment is as unique as the new cheekbones your surgeon just gave you... by that we mean you'll see them all over town. Includes 10-car garage. */,
                62 => "MP_PROP_68DES" /* GXT: Part of The High Life Update. Enjoy ocean views far above the fray of tourists and bums on Del Perro Beach with this lateral living opportunity for the super rich. If we can overpay for something, we have, and we're passing the expense on down to you. Includes 10-car garage. */,
                63 => "MP_PROP_69DES" /* GXT: Part of The High Life Update. Own a piece of glamorous old Vinewood, albeit a very small and expensive piece that's been made to look just like the other super-rich corners of Los Santos. A contemporary lateral living experience with one foot in the past. Includes 10-car garage. */,
                64 => "MP_PROP_70DES" /* GXT: Part of The High Life Update. A picture-perfect lateral living experience in one of Los Santos' most sought-after tower blocks. These gorgeous lateral apartments only become available when hedgefunder residents have massive drug-induced heart attacks or get arrested for killing hookers. Includes 10-car garage. */,
                65 => "MP_PROP_71DES" /* GXT: Part of The High Life Update. Live in the clouds while your bank balance hits the floor. An apartment so conspicuously expensive all your friends will immediately know how much you paid for it. The Downtown lateral living experience for people who secretly want to be LC based. Includes 10-car garage. */,
                66 => "MP_PROP_72DES" /* GXT: Part of The Independence Day Special. Crazy movie director across the road? Check. Astronomically over-priced property where your car has more square footage than you do? Check. If you're looking for the full Vinewood Hills experience, this modest home ticks all the boxes. Includes 6-car garage. */,
                67 => "MP_PROP_73DES" /* GXT: Part of The Independence Day Special. Calling all gentrifiers... El Burro Heights is ripe for hostile takeover! Pack up the espresso machine, labradoodle and deliberately tousled toddler and snap up this property before it's too late! Act now, or you'll be priced out of this neighborhood within a year! Includes 6-car garage. */,
                68 => "MP_PROP_74DES" /* GXT: Part of The Independence Day Special. Check out the water feature in the front yard! This is coastal, provincial living at its very finest. Worried about shade? Want easy access to groceries? How about two for the price of one? This house backs right onto the supermarket, blocking out all natural light. Includes 6-car garage. */,
                69 => "MP_PROP_75DES" /* GXT: Part of The Independence Day Special. Stunning views of rapidly rising sea levels! And talk about amenities! This Paleto Bay beauty is walking distance to a dive bar, hospital, funeral home, crematorium and gun store, so you can go out on the town secure in the knowledge that you're covered for every eventuality. Includes 6-car garage. */,
                70 => "MP_PROP_76DES" /* GXT: Part of The Independence Day Special. Fall asleep to the sounds of the ocean and bums dumpster-diving in the parking lot. This cute-as-a-button property is centrally located on Paleto Bay's main street, a short walk from the coast and next door to the local supermarket. Includes 2-car garage. */,
                71 => "MP_PROP_77DES" /* GXT: Part of The Independence Day Special. Beggars CAN be choosers! Waterfront living at a bargain price! Steps away from both a Chinese restaurant and a tattoo parlor, this Sandy Shores location offers no shortage of late-night decisions you'll regret in the morning. Includes 2-car garage. */,
                72 => "MP_PROP_78DES" /* GXT: Part of The Independence Day Special. Location, location, location! Across from a feed store, minimart and discount clothes emporium, this house is right in the heart of the action on Grapeseed's main drag. Living on the cutting edge of rural retail! Includes 2-car garage. */,
                83 => "MP_PROP_79DES" /* GXT: Is the 1% starting to feel a little crowded? Are you tired of single-digit millionaires cluttering up your elevator and groping your bellboy? Do you need a new way of expressing your bottomless contempt for your fellow man? Look no further: this lavish penthouse suite at the best address in town is expensive enough to keep the riff raff at bay until at least the next federal bailout. Access to our same-day redecorating service included as standard. Part of Executives and Other Criminals. */,
                84 => "MP_PROP_80DES" /* GXT: Penthouse living isn't just about mindless luxury. It's about knowing that when you flush a dump you're literally crapping through every single one of the $500K hovels beneath you - and that's something that only money can buy. Access to our same-day redecorating service included as standard. Part of Executives and Other Criminals. */,
                85 => "MP_PROP_81DES" /* GXT: Let's face it: we had you at the price tag. The fact that this happens to be one of the most decadent living spaces for hundreds of miles doesn't really matter. Just like its new owner, something this expensive doesn't need to be 'nice' or 'useful'. You're a perfect match. What are you waiting for? Access to our same-day redecorating service included as standard. Part of Executives and Other Criminals. */,
                73 => "MP_PROP_83DES" /* GXT: Welcome to the heights of the Vinewood hills, where the average first time buyer is 24 and the web 2.0 entrepreneurs are only outnumbered by the swarms of fading teenage pop sensations. Buy in now while the price is still ridiculously high - what are you, sensible? Part of Executives and Other Criminals. */,
                74 => "MP_PROP_84DES" /* GXT: San Andreas is a place where property values can only go up and high magnitude earthquakes never happen, so where better to balance a luxury apartment on stilts over a steep hillside in a crowded residential area? The first time you feel yourself and everything you own sway in a light breeze you'll be surprised how good this sounded on paper. Part of Executives and Other Criminals. */,
                75 => "MP_PROP_85DES" /* GXT: The previous owner of this gorgeous cliffside manor died doing a yoga pose on the rear balcony railing... but at least they got the Snapmatic shot. It's a tough act to follow, but if you're rich and stupid enough to buy into this neighborhood you're already most of the way there. Just follow your fragile heart. Part of Executives and Other Criminals. */,
                76 => "MP_PROP_86DES" /* GXT: Clinging to the side of the Vinewood hills like a dying oil tycoon clutching his carer-turned-sixth-wife, this three story mansion more than compensates for deep structural flaws with sumptuous interior design. Open plan kitchen, minimalist furnishings, ever-present vertigo: this one really has it all. Part of Executives and Other Criminals. */,
                77 => "MP_PROP_87DES" /* GXT: The saps driving through downtown Vinewood on their morning commute need something to aspire to. They don't want to look up and see green, peaceful hills. They want to gaze through your floor-length windows and see you in nothing but a snakeskin posing pouch injecting cold press kale juice with your tantric yoga instructor. That's the kind of status that doesn't come cheap, so dig deep. Part of Executives and Other Criminals. */,
                78 => "MP_PROP_89DES" /* GXT: Act now to secure your place at one of the quietest and most exclusive addresses in the city. All the other houses on this street were bought in the nineties by legitimate foreign investors who needed somewhere to store vast sums of legally acquired capital, and they've been empty ever since. It'll feel like you're living in an investment portfolio, but isn't that the point? Part of Executives and Other Criminals. */,
                79 => "MP_PROP_90DES" /* GXT: Skyscraper views and lateral living are last year's kind of vanity project. Put a more contemporary spin on your raging superiority complex by forcing your butler to wheeze up and down all three stories of this hillside palace, while you take selfies with the spectacular views of thousands of more comfortable, less expensive places to live behind you. Part of Executives and Other Criminals. */,
                80 => "MP_PROP_92DES" /* GXT: The tinnitus and smoker's cough are telling you that you've seen too much inner-city living, and we're telling you that this fantastically expensive apartment in leafy Vinewood is the answer to decades of hardened self-abuse. From here, you can gaze out across the whole town every morning as you retch into your green juice and paleo breakfast burrito. Just keep reminding yourself you're glad to get away from it all. Part of Executives and Other Criminals. */,
                81 => "MP_PROP_94DES" /* GXT: Built in the 60s and surprising everyone by still being in once piece, this understated property may not look like much on the outside, but don't worry: inside it's identical to every other brainless yuppie's fantasy of open plan, designer living. Part of Executives and Other Criminals. */,
                82 => "MP_PROP_95DES" /* GXT: Designed and constructed in direct violation of every building law in the state, this luxury apartment is a testament to the power of a can-do attitude and utter disregard for standards of health, safety and common sense. Time to pour yourself a drink, forget about the forty foot drop, and congratulate yourself on keeping that pioneer spirit alive. Part of Executives and Other Criminals. */,
                _ => "",
            };
        }

        public string Address(int n)
        {
            return n switch
            {
                1 => "MP_PROP_1A" /* GXT: Eclipse Towers, Apt 31 */,
                2 => "MP_PROP_2A" /* GXT: Eclipse Towers, Apt 9 */,
                3 => "MP_PROP_3A" /* GXT: Eclipse Towers, Apt 40 */,
                4 => "MP_PROP_4A" /* GXT: Eclipse Towers, Apt 5 */,
                5 => "MP_PROP_5A" /* GXT: 3 Alta St, Apt 10 */,
                6 => "MP_PROP_6A" /* GXT: 3 Alta St, Apt 57 */,
                7 => "MP_PROP_7A" /* GXT: Del Perro Heights, Apt 20 */,
                8 => "MP_PROP_8A" /* GXT: 1162 Power St, Apt 3 */,
                9 => "MP_PROP_9A" /* GXT: 0605 Spanish Ave, Apt 1 */,
                10 => "MP_PROP_1A0" /* GXT: 0604 Las Lagunas Blvd, Apt 4 */,
                11 => "MP_PROP_1A1" /* GXT: 0184 Milton Rd, Apt 13 */,
                12 => "MP_PROP_1A2" /* GXT: The Royale, Apt 19 */,
                13 => "MP_PROP_1A3" /* GXT: 0504 S Mo Milton Dr */,
                14 => "MP_PROP_1A4" /* GXT: 0115 Bay City Ave, Apt 45 */,
                15 => "MP_PROP_1A5" /* GXT: 0325 South Rockford Dr */,
                16 => "MP_PROP_1A6" /* GXT: Dream Tower, Apt 15 */,
                17 => "MP_PROP_1A7" /* GXT: 2143 Las Lagunas Blvd, Apt 9 */,
                18 => "MP_PROP_1A8" /* GXT: 1561 San Vitas St, Apt 2 */,
                19 => "MP_PROP_1A9" /* GXT: 0112 S Rockford Dr, Apt 13 */,
                20 => "MP_PROP_2A0" /* GXT: 2057 Vespucci Blvd, Apt 1 */,
                21 => "MP_PROP_2A1" /* GXT: 0069 Cougar Ave, Apt 19 */,
                22 => "MP_PROP_2A2" /* GXT: 1237 Prosperity St, Apt 21 */,
                23 => "MP_PROP_2A3" /* GXT: 1115 Blvd Del Perro, Apt 18 */,
                24 => "MP_PROP_2A4" /* GXT: 0120 Murrieta Heights */,
                25 => "MP_PROP_2A5" /* GXT: Unit 14 Popular St */,
                26 => "MP_PROP_2A6" /* GXT: Unit 2 Popular St */,
                27 => "MP_PROP_2A7" /* GXT: 331 Supply St */,
                28 => "MP_PROP_2A8" /* GXT: Unit 1 Olympic Fwy */,
                29 => "MP_PROP_2A9" /* GXT: 0754 Roy Lowenstein Blvd */,
                30 => "MP_PROP_3A0" /* GXT: 12 Little Bighorn Ave */,
                31 => "MP_PROP_3A1" /* GXT: Unit 124 Popular St */,
                32 => "MP_PROP_3A2" /* GXT: 0552 Roy Lowenstein Blvd */,
                33 => "MP_PROP_3A3" /* GXT: 0432 Davis Ave */,
                34 => "MP_PROP_3A4" /* GXT: Del Perro Heights, Apt 7 */,
                35 => "MP_PROP_3A5" /* GXT: Weazel Plaza, Apt 101 */,
                36 => "MP_PROP_3A6" /* GXT: Weazel Plaza, Apt 70 */,
                37 => "MP_PROP_3A7" /* GXT: Weazel Plaza, Apt 26 */,
                38 => "MP_PROP_3A8" /* GXT: 4 Integrity Way, Apt 30 */,
                39 => "MP_PROP_3A9" /* GXT: 4 Integrity Way, Apt 35 */,
                40 => "MP_PROP_4A0" /* GXT: Richards Majestic, Apt 4 */,
                41 => "MP_PROP_4A1" /* GXT: Richards Majestic, Apt 51 */,
                42 => "MP_PROP_4A2" /* GXT: Tinsel Towers, Apt 45 */,
                43 => "MP_PROP_4A3" /* GXT: Tinsel Towers, Apt 29 */,
                44 => "MP_PROP_4A4" /* GXT: 142 Paleto Blvd */,
                45 => "MP_PROP_4A5" /* GXT: 1 Strawberry Ave */,
                46 => "MP_PROP_4A6" /* GXT: 1932 Grapeseed Ave */,
                47 => "MP_PROP_4A8" /* GXT: 1920 Senora Way */,
                48 => "MP_PROP_4A9" /* GXT: 2000 Great Ocean Highway */,
                49 => "MP_PROP_5A0" /* GXT: 197 Route 68 */,
                50 => "MP_PROP_5A1" /* GXT: 870 Route 68 Approach */,
                51 => "MP_PROP_5A2" /* GXT: 1200 Route 68 */,
                52 => "MP_PROP_5A7" /* GXT: 8754 Route 68 */,
                53 => "MP_PROP_5A9" /* GXT: 1905 Davis Ave */,
                54 => "MP_PROP_6A0" /* GXT: 1623 South Shambles St */,
                55 => "MP_PROP_6A1" /* GXT: 4531 Dry Dock St */,
                56 => "MP_PROP_6A2" /* GXT: 1337 Exceptionalists Way */,
                57 => "MP_PROP_6A3" /* GXT: Unit 76 Greenwich Parkway */,
                58 => "MP_PROP_6A4" /* GXT: Garage Innocence Blvd */,
                59 => "MP_PROP_6A5" /* GXT: 634 Blvd Del Perro */,
                60 => "MP_PROP_6A6" /* GXT: 0897 Mirror Park Blvd */,
                61 => "MP_PROP_6A7" /* GXT: Eclipse Towers, Apt 3 */,
                62 => "MP_PROP_6A8" /* GXT: Del Perro Heights, Apt 4 */,
                63 => "MP_PROP_6A9" /* GXT: Richards Majestic, Apt 2 */,
                64 => "MP_PROP_7A0" /* GXT: Tinsel Towers, Apt 42 */,
                65 => "MP_PROP_7A1" /* GXT: 4 Integrity Way, Apt 28 */,
                66 => "MP_PROP_7A2" /* GXT: 4 Hangman Ave */,
                67 => "MP_PROP_7A3" /* GXT: 12 Sustancia Rd */,
                68 => "MP_PROP_7A4" /* GXT: 4584 Procopio Dr */,
                69 => "MP_PROP_7A5" /* GXT: 4401 Procopio Dr */,
                70 => "MP_PROP_7A6" /* GXT: 0232 Paleto Blvd */,
                71 => "MP_PROP_7A7" /* GXT: 140 Zancudo Ave */,
                72 => "MP_PROP_7A8" /* GXT: 1893 Grapeseed Ave */,
                83 => "MP_PROP_7A9" /* GXT: Eclipse Towers, Penthouse Suite 1 */,
                84 => "MP_PROP_8A0" /* GXT: Eclipse Towers, Penthouse Suite 2 */,
                85 => "MP_PROP_8A1" /* GXT: Eclipse Towers, Penthouse Suite 3 */,
                73 => "MP_PROP_8A3" /* GXT: 3655 Wild Oats Drive */,
                74 => "MP_PROP_8A4" /* GXT: 2044 North Conker Avenue */,
                75 => "MP_PROP_8A5" /* GXT: 2868 Hillcrest Avenue */,
                76 => "MP_PROP_8A6" /* GXT: 2862 Hillcrest Avenue */,
                77 => "MP_PROP_8A7" /* GXT: 3677 Whispymound Drive */,
                78 => "MP_PROP_8A9" /* GXT: 2117 Milton Road */,
                79 => "MP_PROP_9A0" /* GXT: 2866 Hillcrest Avenue */,
                80 => "MP_PROP_9A2" /* GXT: 2874 Hillcrest Avenue */,
                81 => "MP_PROP_9A4" /* GXT: 2113 Mad Wayne Thunder Drive */,
                82 => "MP_PROP_9A5" /* GXT: 2045 North Conker Avenue */,
                _ => "",
            };
        }

        public Apartment(int slot, int id) : base(slot, id)
        {
            if (id == 129)
            {
                BaseCost = Tunables.Global_262145.Value<int>("f_32921");
                Position = new Vector3(-286.2379f, 281.7274f, 88.8872f);
            }
            else
            {
                Position = GetDefaultPosition(id);
                BaseCost = Ceil(GetDefaultPrice(id) * Tunables.Global_262145.Value<float>("f_78") /* Tunable: PROPERTY_MULTIPLIER */);
            }
        }

        public void AddToScaleform(ScaleformWideScreen sc)
        {
            //PROPERTY: [0],
            //INDEX: slot,
            //XPOS: [1],
            //YPOS: [2],
            //PRICE: [3],
            //TXD: [4],
            //DESCRIPTION: [5],
            //SIZE: [6],
            //LOCATION: [7],
            //DLC: [8],
            //SALE: [9],
            //INTERIORS: [10],
            //REBATE: [11],
            //SALE_PRICE: [12],
            //SORTING_PRICE: BaseCost,
            //IS_NEW: [13] !== false,
            //STARTER_PACK: [14],
            //TINTS: [15]
            if (Id == 129)
            {
                int iVar1 = AlternativePrice(1);
                bool bVar2 = BaseCost > iVar1;
                BeginScaleformMovieMethod(sc.Handle, "SET_DATA_SLOT");
                ScaleformMovieMethodAddParamInt(Slot);
                Tools.SetScaleformString("MSG_NME_1");
                ScaleformMovieMethodAddParamFloat(Position.X);
                ScaleformMovieMethodAddParamFloat(Position.Y);
                if (iVar1 < 1 || func_5731(Id))
                    Tools.SetScaleformString("ITEM_FREE" /* GXT: FREE */);
                else
                    ScaleformMovieMethodAddParamInt(BaseCost);
                Tools.SetTextureDictionary("DYN_DLC_GARAGES");
                Tools.SetScaleformString("MP_MSG_DES" /* GXT: Eating, sleeping, and washing? Oh please. Time to up your grindset. Forget about luxury apartments. All you need for a productive lifestyle is a 5-floor private garage with enough storage for up to fifty vehicles. #Simpleliving */);
                ScaleformMovieMethodAddParamInt(12);
                ScaleformMovieMethodAddParamInt(1);
                Tools.SetScaleformString("DYN_CUSTOMGAR" /* GXT: CUSTOM GARAGE */);
                ScaleformMovieMethodAddParamBool(bVar2);
                ScaleformMovieMethodAddParamInt(7);
                Tools.SetScaleformString("");
                if (bVar2)
                    ScaleformMovieMethodAddParamInt(iVar1);
                else
                    ScaleformMovieMethodAddParamInt(0);
                ScaleformMovieMethodAddParamBool(true);
                if (VehicleSitesHandler.func_5728() && func_5727(Id) && func_5731(Id))
                    ScaleformMovieMethodAddParamBool(true);
                else
                    ScaleformMovieMethodAddParamBool(false);
                ScaleformMovieMethodAddParamBool(true);
                EndScaleformMovieMethod();
                return;
            }
            string Var0 = "";
            bool bVar8 = func_7476(Id, ref Var0) == 1;
            bool bVar9 = false;
            BeginScaleformMovieMethod(sc.Handle, "SET_DATA_SLOT");
            ScaleformMovieMethodAddParamInt(Slot);
            Tools.SetScaleformString(Label(Id));
            ScaleformMovieMethodAddParamFloat(Position.X);
            ScaleformMovieMethodAddParamFloat(Position.Y);
            if (bVar8)
            {
                ScaleformMovieMethodAddParamInt(func_6663(Id));
            }
            else
            {
                ScaleformMovieMethodAddParamInt(BaseCost);
            }
            Tools.SetTextureDictionary(TXD(Id));
            Tools.SetScaleformString(Description(Id));
            ScaleformMovieMethodAddParamInt(func_5793(Id));
            ScaleformMovieMethodAddParamInt(func_7475(Id));
            switch (Id)
            {
                case 61:
                case 62:
                case 63:
                case 64:
                case 65:
                    Tools.SetScaleformString("DYN_UPDATEDINT" /* GXT: UPDATED INTERIOR */);
                    break;

                case 73:
                case 74:
                case 75:
                case 76:
                case 77:
                case 78:
                case 79:
                case 80:
                case 81:
                case 82:
                    Tools.SetScaleformString("DYN_STILTAPT" /* GXT: STILT APARTMENT */);
                    bVar9 = true;
                    break;

                case 83:
                case 84:
                case 85:
                    Tools.SetScaleformString("DYN_CUSTOMAPT" /* GXT: CUSTOM APARTMENT */);
                    bVar9 = true;
                    break;

                default:
                    Tools.SetScaleformString("");
                    break;
            }
            ScaleformMovieMethodAddParamBool(bVar8);
            int iVar10 = 0;
            if (func_7474(Id, ref iVar10))
            {
                ScaleformMovieMethodAddParamInt(iVar10);
                Debug.WriteLine("iVar10:" + iVar10);
            }
            else
                ScaleformMovieMethodAddParamInt(0);
            Tools.SetScaleformString(Var0);
            if (bVar8)
                ScaleformMovieMethodAddParamInt(Ceil(GetDefaultPrice(Id) * Tunables.Global_262145.Value<float>("f_78") /* Tunable: PROPERTY_MULTIPLIER */));
            else
                ScaleformMovieMethodAddParamInt(0);
            ScaleformMovieMethodAddParamBool(bVar9);
            if (VehicleSitesHandler.func_5728() && func_5727(Id) && func_5731(Id))
                ScaleformMovieMethodAddParamBool(true);
            else
                ScaleformMovieMethodAddParamBool(false);
            EndScaleformMovieMethod();
        }

        int AlternativePrice(int iParam0)//Position - 0x1CF9DE
        {
            int iVar16;
            int iVar17;

            string sVar0 = $"MULTISTOREY_GARAGE_INDEX_{iParam0}_v0";
            iVar16 = GetHashKey(sVar0);
            if (NetGameserverCatalogItemExistsHash((uint)iVar16))
            {
                iVar17 = NetGameserverGetPrice((uint)iVar16, (uint)GetHashKey("CATEGORY_PROPERTIE"), true);
                return iVar17;
            }

            return iParam0 switch
            {
                1 => Tunables.Global_262145.Value<int>("f_32922") /* Tunable: MULTISTOREY_GARAGE_SALE_ECLIPSE_BLVD */,
                _ => 0,
            };
        }
        bool func_5727(int iParam0)//Position - 0x1D4307
        {
            if (VehicleSitesHandler.func_5728())
            {
                if (iParam0 == 88 || iParam0 == 94 || iParam0 == 18 || iParam0 == 56)
                {
                    return true;
                }
            }
            return false;
        }
        internal bool func_5731(int iParam0)//Position - 0x1D43B6
        {
            if (iParam0 == 31)
            {
                return true;
            }
            if (VehicleSitesHandler.func_5728())
            {
                if (func_5727(iParam0))
                {
                    return true;
                }
            }
            return false;
        }
        int GetDefaultPrice(int iParam0)//Position - 0x1D3A85
        {
            int iVar0;
            bool bVar1;
            int iVar2;

            iVar0 = 0;
            bVar1 = false;
            if (func_5731(iParam0))
            {
                if (!func_5727(iParam0))
                {
                    iVar0 = 1;
                }
                else
                {
                    bVar1 = true;
                }
            }
            iVar2 = func_5724(iParam0, iVar0, bVar1);
            if (NetGameserverCatalogItemExistsHash((uint)iVar2))
            {
                return NetGameserverGetPrice((uint)iVar2, 426439576, true); //(uint)GetHashKey("CATEGORY_PROPERTIE")
            }
            return func_67(iParam0);
        }
        int func_5724(int iParam0, int iParam1, bool bParam2)//Position - 0x1D3AE5
        {
            string sVar0 = "";

            func_5725(ref sVar0, iParam0, iParam1, bParam2);
            return GetHashKey(sVar0);
        }

        void func_5725(ref string sParam0, int iParam1, int iParam2, bool bParam3)//Position - 0x1D3AFF
        {
            string Var0;

            //sParam0 = "FACTORY_INDEX_";
            Var0 = func_5726(iParam1);
            sParam0 += "PR_";
            sParam0 += Var0;
            sParam0 += "_t0_v";
            sParam0 += iParam2;
            if (bParam3)
            {
                sParam0 += "_CESP";
            }
        }
        string func_5726(int iParam0)//Position - 0x1D3B46
        {

            string Var0 = "";

            switch (iParam0)
            {
                case 1:
                    Var0 = "MP_PROP_1" /* GXT: Eclipse Towers, Apt 31 */;
                    break;

                case 2:
                    Var0 = "MP_PROP_2" /* GXT: Eclipse Towers, Apt 9 */;
                    break;

                case 3:
                    Var0 = "MP_PROP_3" /* GXT: Eclipse Towers, Apt 40 */;
                    break;

                case 4:
                    Var0 = "MP_PROP_4" /* GXT: Eclipse Towers, Apt 5 */;
                    break;

                case 5:
                    Var0 = "MP_PROP_5" /* GXT: 3 Alta St, Apt 10 */;
                    break;

                case 6:
                    Var0 = "MP_PROP_6" /* GXT: 3 Alta St, Apt 57 */;
                    break;

                case 7:
                    Var0 = "MP_PROP_7" /* GXT: Del Perro Heights, Apt 20 */;
                    break;

                case 8:
                    Var0 = "MP_PROP_8" /* GXT: 1162 Power St, Apt 3 */;
                    break;

                case 9:
                    Var0 = "MP_PROP_9" /* GXT: 0605 Spanish Ave, Apt 1 */;
                    break;

                case 10:
                    Var0 = "MP_PROP_10" /* GXT: 0604 Las Lagunas Blvd, Apt 4 */;
                    break;

                case 11:
                    Var0 = "MP_PROP_11" /* GXT: 0184 Milton Rd, Apt 13 */;
                    break;

                case 12:
                    Var0 = "MP_PROP_12" /* GXT: The Royale, Apt 19 */;
                    break;

                case 13:
                    Var0 = "MP_PROP_13" /* GXT: 0504 S Mo Milton Dr */;
                    break;

                case 14:
                    Var0 = "MP_PROP_14" /* GXT: 0115 Bay City Ave, Apt 45 */;
                    break;

                case 15:
                    Var0 = "MP_PROP_15" /* GXT: 0325 South Rockford Dr */;
                    break;

                case 16:
                    Var0 = "MP_PROP_16" /* GXT: Dream Tower, Apt 15 */;
                    break;

                case 17:
                    Var0 = "MP_PROP_17" /* GXT: 2143 Las Lagunas Blvd, Apt 9 */;
                    break;

                case 18:
                    Var0 = "MP_PROP_18" /* GXT: 1561 San Vitas St, Apt 2 */;
                    break;

                case 19:
                    Var0 = "MP_PROP_19" /* GXT: 0112 S Rockford Dr, Apt 13 */;
                    break;

                case 20:
                    Var0 = "MP_PROP_20" /* GXT: 2057 Vespucci Blvd, Apt 1 */;
                    break;

                case 21:
                    Var0 = "MP_PROP_21" /* GXT: 0069 Cougar Ave, Apt 19 */;
                    break;

                case 22:
                    Var0 = "MP_PROP_22" /* GXT: 1237 Prosperity St, Apt 21 */;
                    break;

                case 23:
                    Var0 = "MP_PROP_23" /* GXT: 1115 Blvd Del Perro, Apt 18 */;
                    break;

                case 24:
                    Var0 = "MP_PROP_24" /* GXT: 0120 Murrieta Heights */;
                    break;

                case 25:
                    Var0 = "MP_PROP_25" /* GXT: Unit 14 Popular St */;
                    break;

                case 26:
                    Var0 = "MP_PROP_26" /* GXT: Unit 2 Popular St */;
                    break;

                case 27:
                    Var0 = "MP_PROP_27" /* GXT: 331 Supply St */;
                    break;

                case 28:
                    Var0 = "MP_PROP_28" /* GXT: Unit 1 Olympic Fwy */;
                    break;

                case 29:
                    Var0 = "MP_PROP_29" /* GXT: 0754 Roy Lowenstein Blvd */;
                    break;

                case 30:
                    Var0 = "MP_PROP_30" /* GXT: 12 Little Bighorn Ave */;
                    break;

                case 31:
                    Var0 = "MP_PROP_31" /* GXT: Unit 124 Popular St */;
                    break;

                case 32:
                    Var0 = "MP_PROP_32" /* GXT: 0552 Roy Lowenstein Blvd */;
                    break;

                case 33:
                    Var0 = "MP_PROP_33" /* GXT: 0432 Davis Ave */;
                    break;

                case 34:
                    Var0 = "MP_PROP_34" /* GXT: Del Perro Heights, Apt 7 */;
                    break;

                case 35:
                    Var0 = "MP_PROP_35" /* GXT: Weazel Plaza, Apt 101 */;
                    break;

                case 36:
                    Var0 = "MP_PROP_36" /* GXT: Weazel Plaza, Apt 70 */;
                    break;

                case 37:
                    Var0 = "MP_PROP_37" /* GXT: Weazel Plaza, Apt 26 */;
                    break;

                case 38:
                    Var0 = "MP_PROP_38" /* GXT: 4 Integrity Way, Apt 30 */;
                    break;

                case 39:
                    Var0 = "MP_PROP_39" /* GXT: 4 Integrity Way, Apt 35 */;
                    break;

                case 40:
                    Var0 = "MP_PROP_40" /* GXT: Richards Majestic, Apt 4 */;
                    break;

                case 41:
                    Var0 = "MP_PROP_41" /* GXT: Richards Majestic, Apt 51 */;
                    break;

                case 42:
                    Var0 = "MP_PROP_42" /* GXT: Tinsel Towers, Apt 45 */;
                    break;

                case 43:
                    Var0 = "MP_PROP_43" /* GXT: Tinsel Towers, Apt 29 */;
                    break;

                case 44:
                    Var0 = "MP_PROP_44" /* GXT: 142 Paleto Blvd */;
                    break;

                case 45:
                    Var0 = "MP_PROP_45" /* GXT: 1 Strawberry Ave */;
                    break;

                case 46:
                    Var0 = "MP_PROP_46" /* GXT: 1932 Grapeseed Ave */;
                    break;

                case 47:
                    Var0 = "MP_PROP_48" /* GXT: 1920 Senora Way */;
                    break;

                case 48:
                    Var0 = "MP_PROP_49" /* GXT: 2000 Great Ocean Highway */;
                    break;

                case 49:
                    Var0 = "MP_PROP_50" /* GXT: 197 Route 68 */;
                    break;

                case 50:
                    Var0 = "MP_PROP_51" /* GXT: 870 Route 68 Approach */;
                    break;

                case 51:
                    Var0 = "MP_PROP_52" /* GXT: 1200 Route 68 */;
                    break;

                case 52:
                    Var0 = "MP_PROP_57" /* GXT: 8754 Route 68 */;
                    break;

                case 53:
                    Var0 = "MP_PROP_59" /* GXT: 1905 Davis Ave */;
                    break;

                case 54:
                    Var0 = "MP_PROP_60" /* GXT: 1623 South Shambles St */;
                    break;

                case 55:
                    Var0 = "MP_PROP_61" /* GXT: 4531 Dry Dock St */;
                    break;

                case 56:
                    Var0 = "MP_PROP_62" /* GXT: 1337 Exceptionalists Way */;
                    break;

                case 57:
                    Var0 = "MP_PROP_63" /* GXT: Unit 76 Greenwich Parkway */;
                    break;

                case 58:
                    Var0 = "MP_PROP_64" /* GXT: Garage Innocence Blvd */;
                    break;

                case 59:
                    Var0 = "MP_PROP_65" /* GXT: 634 Blvd Del Perro */;
                    break;

                case 60:
                    Var0 = "MP_PROP_66" /* GXT: 0897 Mirror Park Blvd */;
                    break;

                case 61:
                    Var0 = "MP_PROP_67" /* GXT: Eclipse Towers, Apt 3 */;
                    break;

                case 62:
                    Var0 = "MP_PROP_68" /* GXT: Del Perro Heights, Apt 4 */;
                    break;

                case 63:
                    Var0 = "MP_PROP_69" /* GXT: Richards Majestic, Apt 2 */;
                    break;

                case 64:
                    Var0 = "MP_PROP_70" /* GXT: Tinsel Towers, Apt 42 */;
                    break;

                case 65:
                    Var0 = "MP_PROP_71" /* GXT: 4 Integrity Way, Apt 28 */;
                    break;

                case 66:
                    Var0 = "MP_PROP_72" /* GXT: 4 Hangman Ave */;
                    break;

                case 67:
                    Var0 = "MP_PROP_73" /* GXT: 12 Sustancia Rd */;
                    break;

                case 68:
                    Var0 = "MP_PROP_74" /* GXT: 4584 Procopio Dr */;
                    break;

                case 69:
                    Var0 = "MP_PROP_75" /* GXT: 4401 Procopio Dr */;
                    break;

                case 70:
                    Var0 = "MP_PROP_76" /* GXT: 0232 Paleto Blvd */;
                    break;

                case 71:
                    Var0 = "MP_PROP_77" /* GXT: 140 Zancudo Ave */;
                    break;

                case 72:
                    Var0 = "MP_PROP_78" /* GXT: 1893 Grapeseed Ave */;
                    break;

                case 83:
                    Var0 = "MP_PROP_79" /* GXT: Eclipse Towers, Penthouse Suite 1 */;
                    break;

                case 84:
                    Var0 = "MP_PROP_80" /* GXT: Eclipse Towers, Penthouse Suite 2 */;
                    break;

                case 85:
                    Var0 = "MP_PROP_81" /* GXT: Eclipse Towers, Penthouse Suite 3 */;
                    break;

                case 73:
                    Var0 = "MP_PROP_83" /* GXT: 3655 Wild Oats Drive */;
                    break;

                case 74:
                    Var0 = "MP_PROP_84" /* GXT: 2044 North Conker Avenue */;
                    break;

                case 75:
                    Var0 = "MP_PROP_85" /* GXT: 2868 Hillcrest Avenue */;
                    break;

                case 76:
                    Var0 = "MP_PROP_86" /* GXT: 2862 Hillcrest Avenue */;
                    break;

                case 77:
                    Var0 = "MP_PROP_87" /* GXT: 3677 Whispymound Drive */;
                    break;

                case 78:
                    Var0 = "MP_PROP_89" /* GXT: 2117 Milton Road */;
                    break;

                case 79:
                    Var0 = "MP_PROP_90" /* GXT: 2866 Hillcrest Avenue */;
                    break;

                case 80:
                    Var0 = "MP_PROP_92" /* GXT: 2874 Hillcrest Avenue */;
                    break;

                case 81:
                    Var0 = "MP_PROP_94" /* GXT: 2113 Mad Wayne Thunder Drive */;
                    break;

                case 82:
                    Var0 = "MP_PROP_95" /* GXT: 2045 North Conker Avenue */;
                    break;

                case 86:
                    Var0 = "PM_SPAWN_Y" /* GXT: Private Yacht */;
                    break;

                case 87:
                    Var0 = "MP_PROP_OFF1" /* GXT: Lombank West */;
                    break;

                case 88:
                    Var0 = "MP_PROP_OFF2" /* GXT: Maze Bank West */;
                    break;

                case 89:
                    Var0 = "MP_PROP_OFF3" /* GXT: Arcadius Business Center */;
                    break;

                case 90:
                    Var0 = "MP_PROP_OFF4" /* GXT: Maze Bank Tower */;
                    break;

                case 91:
                    Var0 = "MP_PROP_CLUBH1" /* GXT: Rancho Clubhouse */;
                    break;

                case 92:
                    Var0 = "MP_PROP_CLUBH2" /* GXT: Del Perro Beach Clubhouse */;
                    break;

                case 93:
                    Var0 = "MP_PROP_CLUBH3" /* GXT: Pillbox Hill Clubhouse */;
                    break;

                case 94:
                    Var0 = "MP_PROP_CLUBH4" /* GXT: Great Chaparral Clubhouse */;
                    break;

                case 95:
                    Var0 = "MP_PROP_CLUBH5" /* GXT: Paleto Bay Clubhouse */;
                    break;

                case 96:
                    Var0 = "MP_PROP_CLUBH6" /* GXT: Sandy Shores Clubhouse */;
                    break;

                case 97:
                    Var0 = "MP_PROP_CLUBH7" /* GXT: La Mesa Clubhouse */;
                    break;

                case 98:
                    Var0 = "MP_PROP_CLUBH8" /* GXT: Downtown Vinewood Clubhouse */;
                    break;

                case 99:
                    Var0 = "MP_PROP_CLUBH9" /* GXT: Hawick Clubhouse */;
                    break;

                case 100:
                    Var0 = "MP_PROP_CLUBH10" /* GXT: Grapeseed Clubhouse */;
                    break;

                case 101:
                    Var0 = "MP_PROP_CLUBH11" /* GXT: Paleto Bay Clubhouse */;
                    break;

                case 102:
                    Var0 = "MP_PROP_CLUBH12" /* GXT: Vespucci Beach Clubhouse */;
                    break;

                case 103:
                case 106:
                case 109:
                case 112:
                    Var0 = "MP_PROP_OFFG1" /* GXT: Office Garage 1 */;
                    break;

                case 104:
                case 107:
                case 110:
                case 113:
                    Var0 = "MP_PROP_OFFG2" /* GXT: Office Garage 2 */;
                    break;

                case 105:
                case 108:
                case 111:
                case 114:
                    Var0 = "MP_PROP_OFFG3" /* GXT: Office Garage 3 */;
                    break;

                case 115:
                    Var0 = "IE_WARE_1" /* GXT: Vehicle Warehouse */;
                    break;
            }
            return Var0;
        }
        int func_7476(int iParam0, ref string sParam1)//Position - 0x27D25B
        {
            int iVar0 = -1;
            if (iParam0 == 999)
            {
                sParam1 = "WEB_VEHICLE_CASH_BACK" /* GXT: CASH BACK */;
                return 1;
            }
            else if (func_7477(Label(iParam0), ref iVar0) == 1)
            {
                sParam1 = "WEB_VEHICLE_REBATE" /* GXT: SPECIAL REBATE */;
                return 0;
            }
            else if (func_7328(iParam0) == 1)
            {
                sParam1 = "";
                return 1;
            }
            sParam1 = "";
            return 0;
        }

        int func_7477(string uParam0, ref int iParam4)//Position - 0x27D2BE
        {
            int iVar0;

            if (Tunables.Global_262145.Value<int>("f_13535") == 1 /* Tunable: REBATE_PROPERTY_ALL */)
            {
                iParam4 = GetHashKey("REBATE_PROPERTY_ALL");
                return 1;
            }
            iVar0 = GetHashKey(uParam0);
            if (iVar0 == Tunables.Global_262145.Value<int>("f_12938") /* Tunable: REBATE_PROPERTY_0 */)
            {
                iParam4 = 0;
                return 1;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_12939") /* Tunable: REBATE_PROPERTY_1 */)
            {
                iParam4 = 1;
                return 1;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_12940") /* Tunable: REBATE_PROPERTY_2 */)
            {
                iParam4 = 2;
                return 1;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_12941") /* Tunable: REBATE_PROPERTY_3 */)
            {
                iParam4 = 3;
                return 1;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_12942") /* Tunable: REBATE_PROPERTY_4 */)
            {
                iParam4 = 4;
                return 1;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_12943") /* Tunable: REBATE_PROPERTY_5 */)
            {
                iParam4 = 5;
                return 1;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_12944") /* Tunable: REBATE_PROPERTY_6 */)
            {
                iParam4 = 6;
                return 1;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_12945") /* Tunable: REBATE_PROPERTY_7 */)
            {
                iParam4 = 7;
                return 1;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_12946") /* Tunable: REBATE_PROPERTY_8 */)
            {
                iParam4 = 8;
                return 1;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_12947") /* Tunable: REBATE_PROPERTY_9 */)
            {
                iParam4 = 9;
                return 1;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_12948") /* Tunable: REBATE_PROPERTY_10 */)
            {
                iParam4 = 10;
                return 1;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_12949") /* Tunable: REBATE_PROPERTY_11 */)
            {
                iParam4 = 11;
                return 1;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_12950") /* Tunable: REBATE_PROPERTY_12 */)
            {
                iParam4 = 12;
                return 1;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_12951") /* Tunable: REBATE_PROPERTY_13 */)
            {
                iParam4 = 13;
                return 1;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_12952") /* Tunable: REBATE_PROPERTY_14 */)
            {
                iParam4 = 14;
                return 1;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_12953") /* Tunable: REBATE_PROPERTY_15 */)
            {
                iParam4 = 15;
                return 1;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_12954") /* Tunable: REBATE_PROPERTY_16 */)
            {
                iParam4 = 16;
                return 1;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_12955") /* Tunable: REBATE_PROPERTY_17 */)
            {
                iParam4 = 17;
                return 1;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_12956") /* Tunable: REBATE_PROPERTY_18 */)
            {
                iParam4 = 18;
                return 1;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_12957") /* Tunable: REBATE_PROPERTY_19 */)
            {
                iParam4 = 19;
                return 1;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_12958") /* Tunable: REBATE_PROPERTY_20 */)
            {
                iParam4 = 20;
                return 1;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_12959") /* Tunable: REBATE_PROPERTY_21 */)
            {
                iParam4 = 21;
                return 1;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_12960") /* Tunable: REBATE_PROPERTY_22 */)
            {
                iParam4 = 22;
                return 1;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_12961") /* Tunable: REBATE_PROPERTY_23 */)
            {
                iParam4 = 23;
                return 1;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_12962") /* Tunable: REBATE_PROPERTY_24 */)
            {
                iParam4 = 24;
                return 1;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_12963") /* Tunable: REBATE_PROPERTY_25 */)
            {
                iParam4 = 25;
                return 1;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_12964") /* Tunable: REBATE_PROPERTY_26 */)
            {
                iParam4 = 26;
                return 1;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_12965") /* Tunable: REBATE_PROPERTY_27 */)
            {
                iParam4 = 27;
                return 1;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_12966") /* Tunable: REBATE_PROPERTY_28 */)
            {
                iParam4 = 28;
                return 1;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_12967") /* Tunable: REBATE_PROPERTY_29 */)
            {
                iParam4 = 29;
                return 1;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_12968") /* Tunable: REBATE_PROPERTY_30 */)
            {
                iParam4 = 30;
                return 1;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_12969") /* Tunable: REBATE_PROPERTY_31 */)
            {
                iParam4 = 31;
                return 1;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_12970") /* Tunable: REBATE_PROPERTY_32 */)
            {
                iParam4 = 32;
                return 1;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_12971") /* Tunable: REBATE_PROPERTY_33 */)
            {
                iParam4 = 33;
                return 1;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_12972") /* Tunable: REBATE_PROPERTY_34 */)
            {
                iParam4 = 34;
                return 1;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_12973") /* Tunable: REBATE_PROPERTY_35 */)
            {
                iParam4 = 35;
                return 1;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_12974") /* Tunable: REBATE_PROPERTY_36 */)
            {
                iParam4 = 36;
                return 1;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_12975") /* Tunable: REBATE_PROPERTY_37 */)
            {
                iParam4 = 37;
                return 1;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_12976") /* Tunable: REBATE_PROPERTY_38 */)
            {
                iParam4 = 38;
                return 1;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_12977") /* Tunable: REBATE_PROPERTY_39 */)
            {
                iParam4 = 39;
                return 1;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_12978") /* Tunable: REBATE_PROPERTY_40 */)
            {
                iParam4 = 40;
                return 1;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_12979") /* Tunable: REBATE_PROPERTY_41 */)
            {
                iParam4 = 41;
                return 1;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_12980") /* Tunable: REBATE_PROPERTY_42 */)
            {
                iParam4 = 42;
                return 1;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_12981") /* Tunable: REBATE_PROPERTY_43 */)
            {
                iParam4 = 43;
                return 1;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_12982") /* Tunable: REBATE_PROPERTY_44 */)
            {
                iParam4 = 44;
                return 1;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_12983") /* Tunable: REBATE_PROPERTY_45 */)
            {
                iParam4 = 45;
                return 1;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_12984") /* Tunable: REBATE_PROPERTY_46 */)
            {
                iParam4 = 46;
                return 1;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_12985") /* Tunable: REBATE_PROPERTY_47 */)
            {
                iParam4 = 47;
                return 1;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_12986") /* Tunable: REBATE_PROPERTY_48 */)
            {
                iParam4 = 48;
                return 1;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_12987") /* Tunable: REBATE_PROPERTY_49 */)
            {
                iParam4 = 49;
                return 1;
            }
            iParam4 = -1;
            return 0;
        }
        int func_7328(int iParam0)//Position - 0x26810A
        {
            int iVar0;
            int iVar1;
            int iVar2;

            iVar0 = -1;
            if (Tunables.Global_262145.Value<int>("f_13353") == 1/* Tunable: PROPERTYWEBSITE_SALE */ && func_7329(Label(iParam0), ref iVar0) == 0)
            {
                if (func_5731(iParam0))
                {
                    return 0;
                }
                iVar1 = func_6628(iParam0);
                iVar2 = func_6663(iParam0);
                if (iVar2 != 0 && iVar2 > iVar1)
                {
                    return 1;
                }
            }
            return 0;
        }
        int func_7329(string uParam0, ref int iParam4)//Position - 0x268171
        {
            int iVar0;

            iVar0 = GetHashKey(uParam0);
            if (iVar0 == Tunables.Global_262145.Value<int>("f_13601") /* Tunable: OPTOUT_PROPERTYWEBSITE_SALE0 */)
            {
                iParam4 = 0;
                return 1;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_13602") /* Tunable: OPTOUT_PROPERTYWEBSITE_SALE1 */)
            {
                iParam4 = 1;
                return 1;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_13603") /* Tunable: OPTOUT_PROPERTYWEBSITE_SALE2 */)
            {
                iParam4 = 2;
                return 1;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_13604") /* Tunable: OPTOUT_PROPERTYWEBSITE_SALE3 */)
            {
                iParam4 = 3;
                return 1;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_13605") /* Tunable: OPTOUT_PROPERTYWEBSITE_SALE4 */)
            {
                iParam4 = 4;
                return 1;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_13606") /* Tunable: OPTOUT_PROPERTYWEBSITE_SALE5 */)
            {
                iParam4 = 5;
                return 1;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_13607") /* Tunable: OPTOUT_PROPERTYWEBSITE_SALE6 */)
            {
                iParam4 = 6;
                return 1;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_13608") /* Tunable: OPTOUT_PROPERTYWEBSITE_SALE7 */)
            {
                iParam4 = 7;
                return 1;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_13609") /* Tunable: OPTOUT_PROPERTYWEBSITE_SALE8 */)
            {
                iParam4 = 8;
                return 1;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_13610") /* Tunable: OPTOUT_PROPERTYWEBSITE_SALE9 */)
            {
                iParam4 = 9;
                return 1;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_13611") /* Tunable: OPTOUT_PROPERTYWEBSITE_SALE10 */)
            {
                iParam4 = 10;
                return 1;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_13612") /* Tunable: OPTOUT_PROPERTYWEBSITE_SALE11 */)
            {
                iParam4 = 11;
                return 1;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_13613") /* Tunable: OPTOUT_PROPERTYWEBSITE_SALE12 */)
            {
                iParam4 = 12;
                return 1;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_13614") /* Tunable: OPTOUT_PROPERTYWEBSITE_SALE13 */)
            {
                iParam4 = 13;
                return 1;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_13615") /* Tunable: OPTOUT_PROPERTYWEBSITE_SALE14 */)
            {
                iParam4 = 14;
                return 1;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_13616") /* Tunable: OPTOUT_PROPERTYWEBSITE_SALE15 */)
            {
                iParam4 = 15;
                return 1;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_13617") /* Tunable: OPTOUT_PROPERTYWEBSITE_SALE16 */)
            {
                iParam4 = 16;
                return 1;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_13618") /* Tunable: OPTOUT_PROPERTYWEBSITE_SALE17 */)
            {
                iParam4 = 17;
                return 1;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_13619") /* Tunable: OPTOUT_PROPERTYWEBSITE_SALE18 */)
            {
                iParam4 = 18;
                return 1;
            }
            else if (iVar0 == Tunables.Global_262145.Value<int>("f_13620") /* Tunable: OPTOUT_PROPERTYWEBSITE_SALE19 */)
            {
                iParam4 = 19;
                return 1;
            }
            iParam4 = -1;
            return 0;
        }
        int func_6628(int iParam0)//Position - 0x20F426
        {
            int iVar0;
            bool bVar1;
            string sVar2 = "";
            int iVar18;
            int iVar19;


            iVar0 = 0;
            bVar1 = false;
            if (func_5731(iParam0))
            {
                if (!func_5727(iParam0))
                {
                    iVar0 = 1;
                }
                else
                {
                    bVar1 = true;
                }
            }
            func_5725(ref sVar2, iParam0, iVar0, bVar1);
            iVar18 = GetHashKey(sVar2);
            if (NetGameserverCatalogItemExistsHash((uint)iVar18))
            {
                iVar19 = NetGameserverGetPrice((uint)iVar18, (uint)GetHashKey("CATEGORY_PROPERTIE"), true);
                return iVar19;
            }

            return iParam0 switch
            {
                1 => Tunables.Global_262145.Value<int>("f_3960") /* Tunable: PROPERTY_HIGH_APT_1_EXPENDITURE_MODIFIER */,
                2 => Tunables.Global_262145.Value<int>("f_3961") /* Tunable: PROPERTY_HIGH_APT_2_EXPENDITURE_MODIFIER */,
                3 => Tunables.Global_262145.Value<int>("f_3962") /* Tunable: PROPERTY_HIGH_APT_3_EXPENDITURE_MODIFIER */,
                4 => Tunables.Global_262145.Value<int>("f_3963") /* Tunable: PROPERTY_HIGH_APT_4_EXPENDITURE_MODIFIER */,
                5 => Tunables.Global_262145.Value<int>("f_3964") /* Tunable: PROPERTY_HIGH_APT_5_EXPENDITURE_MODIFIER */,
                6 => Tunables.Global_262145.Value<int>("f_3965") /* Tunable: PROPERTY_HIGH_APT_6_EXPENDITURE_MODIFIER */,
                7 => Tunables.Global_262145.Value<int>("f_3966") /* Tunable: PROPERTY_HIGH_APT_7_EXPENDITURE_MODIFIER */,
                34 => Tunables.Global_262145.Value<int>("f_3967") /* Tunable: PROPERTY_HIGH_APT_8_EXPENDITURE_MODIFIER */,
                35 => Tunables.Global_262145.Value<int>("f_3968") /* Tunable: PROPERTY_HIGH_APT_9_EXPENDITURE_MODIFIER */,
                36 => Tunables.Global_262145.Value<int>("f_3969") /* Tunable: PROPERTY_HIGH_APT_10_EXPENDITURE_MODIFIER */,
                37 => Tunables.Global_262145.Value<int>("f_3970") /* Tunable: PROPERTY_HIGH_APT_11_EXPENDITURE_MODIFIER */,
                38 => Tunables.Global_262145.Value<int>("f_3971") /* Tunable: PROPERTY_HIGH_APT_12_EXPENDITURE_MODIFIER */,
                39 => Tunables.Global_262145.Value<int>("f_3972") /* Tunable: PROPERTY_HIGH_APT_13_EXPENDITURE_MODIFIER */,
                40 => Tunables.Global_262145.Value<int>("f_3973") /* Tunable: PROPERTY_HIGH_APT_14_EXPENDITURE_MODIFIER */,
                41 => Tunables.Global_262145.Value<int>("f_3974") /* Tunable: PROPERTY_HIGH_APT_15_EXPENDITURE_MODIFIER */,
                42 => Tunables.Global_262145.Value<int>("f_3975") /* Tunable: PROPERTY_HIGH_APT_16_EXPENDITURE_MODIFIER */,
                43 => Tunables.Global_262145.Value<int>("f_3976") /* Tunable: PROPERTY_HIGH_APT_17_EXPENDITURE_MODIFIER */,
                8 => Tunables.Global_262145.Value<int>("f_3977") /* Tunable: PROPERTY_MEDIUM_APT_1_EXPENDITURE_MODIFIER */,
                9 => Tunables.Global_262145.Value<int>("f_3978") /* Tunable: PROPERTY_MEDIUM_APT_2_EXPENDITURE_MODIFIER */,
                10 => Tunables.Global_262145.Value<int>("f_3979") /* Tunable: PROPERTY_MEDIUM_APT_3_EXPENDITURE_MODIFIER */,
                11 => Tunables.Global_262145.Value<int>("f_3980") /* Tunable: PROPERTY_MEDIUM_APT_4_EXPENDITURE_MODIFIER */,
                12 => Tunables.Global_262145.Value<int>("f_3981") /* Tunable: PROPERTY_MEDIUM_APT_5_EXPENDITURE_MODIFIER */,
                13 => Tunables.Global_262145.Value<int>("f_3982") /* Tunable: PROPERTY_MEDIUM_APT_6_EXPENDITURE_MODIFIER */,
                14 => Tunables.Global_262145.Value<int>("f_3983") /* Tunable: PROPERTY_MEDIUM_APT_7_EXPENDITURE_MODIFIER */,
                15 => Tunables.Global_262145.Value<int>("f_3984") /* Tunable: PROPERTY_MEDIUM_APT_8_EXPENDITURE_MODIFIER */,
                16 => Tunables.Global_262145.Value<int>("f_3985") /* Tunable: PROPERTY_MEDIUM_APT_9_EXPENDITURE_MODIFIER */,
                17 => Tunables.Global_262145.Value<int>("f_3986") /* Tunable: PROPERTY_LOW_APT_1_EXPENDITURE_MODIFIER */,
                18 => Tunables.Global_262145.Value<int>("f_3987") /* Tunable: PROPERTY_LOW_APT_2_EXPENDITURE_MODIFIER */,
                19 => Tunables.Global_262145.Value<int>("f_3988") /* Tunable: PROPERTY_LOW_APT_3_EXPENDITURE_MODIFIER */,
                20 => Tunables.Global_262145.Value<int>("f_3989") /* Tunable: PROPERTY_LOW_APT_4_EXPENDITURE_MODIFIER */,
                21 => Tunables.Global_262145.Value<int>("f_3990") /* Tunable: PROPERTY_LOW_APT_5_EXPENDITURE_MODIFIER */,
                22 => Tunables.Global_262145.Value<int>("f_3991") /* Tunable: PROPERTY_LOW_APT_6_EXPENDITURE_MODIFIER */,
                23 => Tunables.Global_262145.Value<int>("f_3992") /* Tunable: PROPERTY_LOW_APT_7_EXPENDITURE_MODIFIER */,
                24 => Tunables.Global_262145.Value<int>("f_3993") /* Tunable: PROPERTY_GARAGE_EAST_LOS_SANTOS_1_EXPENDITURE_MODIFIER */,
                25 => Tunables.Global_262145.Value<int>("f_3994") /* Tunable: PROPERTY_GARAGE_EAST_LOS_SANTOS_2_EXPENDITURE_MODIFIER */,
                26 => Tunables.Global_262145.Value<int>("f_3995") /* Tunable: PROPERTY_GARAGE_EAST_LOS_SANTOS_3_EXPENDITURE_MODIFIER */,
                27 => Tunables.Global_262145.Value<int>("f_3996") /* Tunable: PROPERTY_GARAGE_EAST_LOS_SANTOS_4_EXPENDITURE_MODIFIER */,
                28 => Tunables.Global_262145.Value<int>("f_3997") /* Tunable: PROPERTY_GARAGE_EAST_LOS_SANTOS_5_EXPENDITURE_MODIFIER */,
                29 => Tunables.Global_262145.Value<int>("f_3998") /* Tunable: PROPERTY_GARAGE_EAST_LOS_SANTOS_6_EXPENDITURE_MODIFIER */,
                30 => Tunables.Global_262145.Value<int>("f_3999") /* Tunable: PROPERTY_GARAGE_EAST_LOS_SANTOS_7_EXPENDITURE_MODIFIER */,
                31 => Tunables.Global_262145.Value<int>("f_4000") /* Tunable: PROPERTY_GARAGE_EAST_LOS_SANTOS_8_EXPENDITURE_MODIFIER */,
                32 => Tunables.Global_262145.Value<int>("f_4001") /* Tunable: PROPERTY_GARAGE_SOUTH_LOS_SANTOS_1_EXPENDITURE_MODIFIER */,
                33 => Tunables.Global_262145.Value<int>("f_4002") /* Tunable: PROPERTY_GARAGE_SOUTH_LOS_SANTOS_2_EXPENDITURE_MODIFIER */,
                44 => Tunables.Global_262145.Value<int>("f_4003") /* Tunable: PROPERTY_GARAGE_NEW_1_EXPENDITURE_MODIFIER */,
                45 => Tunables.Global_262145.Value<int>("f_4004") /* Tunable: PROPERTY_GARAGE_NEW_2_EXPENDITURE_MODIFIER */,
                46 => Tunables.Global_262145.Value<int>("f_4005") /* Tunable: PROPERTY_GARAGE_NEW_3_EXPENDITURE_MODIFIER */,
                47 => Tunables.Global_262145.Value<int>("f_4006") /* Tunable: PROPERTY_GARAGE_NEW_5_EXPENDITURE_MODIFIER */,
                48 => Tunables.Global_262145.Value<int>("f_4007") /* Tunable: PROPERTY_GARAGE_NEW_6_EXPENDITURE_MODIFIER */,
                49 => Tunables.Global_262145.Value<int>("f_4008") /* Tunable: PROPERTY_GARAGE_NEW_7_EXPENDITURE_MODIFIER */,
                50 => Tunables.Global_262145.Value<int>("f_4009") /* Tunable: PROPERTY_GARAGE_NEW_8_EXPENDITURE_MODIFIER */,
                51 => Tunables.Global_262145.Value<int>("f_4010") /* Tunable: PROPERTY_GARAGE_NEW_9_EXPENDITURE_MODIFIER */,
                52 => Tunables.Global_262145.Value<int>("f_4011") /* Tunable: PROPERTY_GARAGE_NEW_14_EXPENDITURE_MODIFIER */,
                53 => Tunables.Global_262145.Value<int>("f_4012") /* Tunable: PROPERTY_GARAGE_NEW_16_EXPENDITURE_MODIFIER */,
                54 => Tunables.Global_262145.Value<int>("f_4013") /* Tunable: PROPERTY_GARAGE_NEW_17_EXPENDITURE_MODIFIER */,
                55 => Tunables.Global_262145.Value<int>("f_4014") /* Tunable: PROPERTY_GARAGE_NEW_18_EXPENDITURE_MODIFIER */,
                56 => Tunables.Global_262145.Value<int>("f_4015") /* Tunable: PROPERTY_GARAGE_NEW_19_EXPENDITURE_MODIFIER */,
                57 => Tunables.Global_262145.Value<int>("f_4016") /* Tunable: PROPERTY_GARAGE_NEW_20_EXPENDITURE_MODIFIER */,
                58 => Tunables.Global_262145.Value<int>("f_4017") /* Tunable: PROPERTY_GARAGE_NEW_21_EXPENDITURE_MODIFIER */,
                59 => Tunables.Global_262145.Value<int>("f_4018") /* Tunable: PROPERTY_GARAGE_NEW_22_EXPENDITURE_MODIFIER */,
                60 => Tunables.Global_262145.Value<int>("f_4019") /* Tunable: PROPERTY_GARAGE_NEW_23_EXPENDITURE_MODIFIER */,
                61 => Tunables.Global_262145.Value<JArray>("f_7146").ToObject<List<int>>()[0],
                62 => Tunables.Global_262145.Value<JArray>("f_7146").ToObject<List<int>>()[1],
                63 => Tunables.Global_262145.Value<JArray>("f_7146").ToObject<List<int>>()[2],
                64 => Tunables.Global_262145.Value<JArray>("f_7146").ToObject<List<int>>()[3],
                65 => Tunables.Global_262145.Value<JArray>("f_7146").ToObject<List<int>>()[4],
                66 => Tunables.Global_262145.Value<int>("f_8461") /* Tunable: PROPERTY_3_ACE_JONES_DR */,
                67 => Tunables.Global_262145.Value<int>("f_8462") /* Tunable: PROPERTY_12_SUSTANCIA_RD */,
                68 => Tunables.Global_262145.Value<int>("f_8463") /* Tunable: PROPERTY_4584_PROCOPIO_DR */,
                69 => Tunables.Global_262145.Value<int>("f_8464") /* Tunable: PROPERTY_4401_PROCOPIO_DR */,
                70 => Tunables.Global_262145.Value<int>("f_8465") /* Tunable: PROPERTY_0232_PALETO_BLVD */,
                71 => Tunables.Global_262145.Value<int>("f_8466") /* Tunable: PROPERTY_140_ZANCUDO_AVE */,
                72 => Tunables.Global_262145.Value<int>("f_8467") /* Tunable: PROPERTY_1893_GRAPESEED_AVE */,
                73 => Tunables.Global_262145.Value<int>("f_13488") /* Tunable: APARTMENT_CAR_MODSSTILT_3655_WILD_OATS_DRIVE */,
                74 => Tunables.Global_262145.Value<int>("f_13489") /* Tunable: APARTMENT_CAR_MODSSTILT_2044_NORTH_CONKER_AVENUE */,
                75 => Tunables.Global_262145.Value<int>("f_13490") /* Tunable: APARTMENT_CAR_MODSSTILT_2868_HILLCREST_AVENUE */,
                76 => Tunables.Global_262145.Value<int>("f_13491") /* Tunable: APARTMENT_CAR_MODSSTILT_2862_HILLCREST_AVENUE */,
                77 => Tunables.Global_262145.Value<int>("f_13492") /* Tunable: APARTMENT_CAR_MODSSTILT_3677_WHISPYMOUND_DRIVE */,
                78 => Tunables.Global_262145.Value<int>("f_13493") /* Tunable: APARTMENT_CAR_MODSSTILT_2117_MILTON_ROAD */,
                79 => Tunables.Global_262145.Value<int>("f_13494") /* Tunable: APARTMENT_CAR_MODSSTILT_2866_HILLCREST_AVENUE */,
                80 => Tunables.Global_262145.Value<int>("f_13495") /* Tunable: APARTMENT_CAR_MODSSTILT_2874_HILLCREST_AVENUE */,
                81 => Tunables.Global_262145.Value<int>("f_13496") /* Tunable: APARTMENT_CAR_MODSSTILT_2113_MAD_WAYNE_THUNDER_DRIVE */,
                82 => Tunables.Global_262145.Value<int>("f_13497") /* Tunable: APARTMENT_CAR_MODSSTILT_2045_NORTH_CONKER_AVENUE */,
                83 => Tunables.Global_262145.Value<int>("f_13485") /* Tunable: APARTMENT_CAR_MODSECLIPSE_TOWERS_PENTHOUSE_SUITE_1 */,
                84 => Tunables.Global_262145.Value<int>("f_13486") /* Tunable: APARTMENT_CAR_MODSECLIPSE_TOWERS_PENTHOUSE_SUITE_2 */,
                85 => Tunables.Global_262145.Value<int>("f_13487") /* Tunable: APARTMENT_CAR_MODSECLIPSE_TOWERS_PENTHOUSE_SUITE_3 */,
                86 => 27000000,
                87 => Tunables.Global_262145.Value<int>("f_16072") /* Tunable: EXEC1_OFFICE1_LOMBANK */,
                88 => Tunables.Global_262145.Value<int>("f_16073") /* Tunable: EXEC1_OFFICE2_MAZE1 */,
                89 => Tunables.Global_262145.Value<int>("f_16074") /* Tunable: EXEC1_OFFICE3_ARCADIUS */,
                90 => Tunables.Global_262145.Value<int>("f_16075") /* Tunable: EXEC1_OFFICE4_MAZE2 */,
                91 => Tunables.Global_262145.Value<int>("f_18167") /* Tunable: 819519215 */,
                92 => Tunables.Global_262145.Value<int>("f_18169") /* Tunable: 471352940 */,
                93 => Tunables.Global_262145.Value<int>("f_18165") /* Tunable: 2023136086 */,
                94 => Tunables.Global_262145.Value<int>("f_18174") /* Tunable: 217858651 */,
                95 => Tunables.Global_262145.Value<int>("f_18171") /* Tunable: -1058611921 */,
                96 => Tunables.Global_262145.Value<int>("f_18173") /* Tunable: -1767762009 */,
                97 => Tunables.Global_262145.Value<int>("f_18166") /* Tunable: -1390109608 */,
                98 => Tunables.Global_262145.Value<int>("f_18164") /* Tunable: 2033735347 */,
                99 => Tunables.Global_262145.Value<int>("f_18163") /* Tunable: -1219608517 */,
                100 => Tunables.Global_262145.Value<int>("f_18172") /* Tunable: 1669688233 */,
                101 => Tunables.Global_262145.Value<int>("f_18170") /* Tunable: 1241258301 */,
                102 => Tunables.Global_262145.Value<int>("f_18168") /* Tunable: 813618473 */,
                103 => Tunables.Global_262145.Value<int>("f_19835") /* Tunable: IMPEXP_GARAGE_LEVEL1 */,
                104 => Tunables.Global_262145.Value<int>("f_19728") /* Tunable: IMPEXP_GARAGE_LEVEL2_COST */,
                105 => Tunables.Global_262145.Value<int>("f_19729") /* Tunable: IMPEXP_GARAGE_LEVEL3_COST */,
                106 => Tunables.Global_262145.Value<int>("f_19835") /* Tunable: IMPEXP_GARAGE_LEVEL1 */,
                107 => Tunables.Global_262145.Value<int>("f_19728") /* Tunable: IMPEXP_GARAGE_LEVEL2_COST */,
                108 => Tunables.Global_262145.Value<int>("f_19729") /* Tunable: IMPEXP_GARAGE_LEVEL3_COST */,
                109 => Tunables.Global_262145.Value<int>("f_19835") /* Tunable: IMPEXP_GARAGE_LEVEL1 */,
                110 => Tunables.Global_262145.Value<int>("f_19728") /* Tunable: IMPEXP_GARAGE_LEVEL2_COST */,
                111 => Tunables.Global_262145.Value<int>("f_19729") /* Tunable: IMPEXP_GARAGE_LEVEL3_COST */,
                112 => Tunables.Global_262145.Value<int>("f_19835") /* Tunable: IMPEXP_GARAGE_LEVEL1 */,
                113 => Tunables.Global_262145.Value<int>("f_19728") /* Tunable: IMPEXP_GARAGE_LEVEL2_COST */,
                114 => Tunables.Global_262145.Value<int>("f_19729") /* Tunable: IMPEXP_GARAGE_LEVEL3_COST */,
                115 => 3000000,
                _ => 0,
            };
        }
        int func_6663(int iParam0)//Position - 0x211CCE
        {
            return iParam0 switch
            {
                1 => 400000,
                2 => 373000,
                3 => 391000,
                4 => 382000,
                5 => 217000,
                6 => 223000,
                7 => 205000,
                34 => 200000,
                35 => 335000,
                36 => 319000,
                37 => 304000,
                38 => 235000,
                39 => 247000,
                40 => 241000,
                41 => 253000,
                42 => 270000,
                43 => 286000,
                8 => 130000,
                9 => 128000,
                10 => 126000,
                11 => 146000,
                12 => 125000,
                13 => 141000,
                14 => 150000,
                15 => 137000,
                16 => 134000,
                17 => 115000,
                18 => 99000,
                19 => 80000,
                20 => 87000,
                21 => 112000,
                22 => 105000,
                23 => 93000,
                24 => 150000,
                25 => 77500,
                26 => 142500,
                27 => 135000,
                28 => 70000,
                29 => 29500,
                30 => 32000,
                31 => 25000,
                32 => 80000,
                33 => 72500,
                44 => 26500,
                45 => 26000,
                46 => 27500,
                47 => 32000,
                48 => 31500,
                49 => 29000,
                50 => 62500,
                51 => 28000,
                52 => 65000,
                53 => 75000,
                54 => 105000,
                55 => 67500,
                56 => 112500,
                57 => 120000,
                58 => 34000,
                59 => 33500,
                60 => 35000,
                61 => 500000,
                62 => 468000,
                63 => 484000,
                64 => 492000,
                65 => 476000,
                66 => 175000,
                67 => 143000,
                68 => 155000,
                69 => 165000,
                70 => 121000,
                71 => 120000,
                72 => 118000,
                73 => 800000,
                74 => 762000,
                75 => 672000,
                76 => 705000,
                77 => 478000,
                78 => 608000,
                79 => 525000,
                80 => 571000,
                81 => 449000,
                82 => 727000,
                83 => 985000,
                84 => 905000,
                85 => 1100000,
                86 => 27000000,
                87 => 3100000,
                88 => 1000000,
                89 => 2250000,
                90 => 4000000,
                91 => 420000,
                92 => 365000,
                93 => 455000,
                94 => 200000,
                95 => 242000,
                96 => 210000,
                97 => 449000,
                98 => 472000,
                99 => 495000,
                100 => 225000,
                101 => 250000,
                102 => 395000,
                103 => 1150000,
                104 => 855000,
                105 => 745000,
                106 => 1150000,
                107 => 855000,
                108 => 745000,
                109 => 1150000,
                110 => 855000,
                111 => 745000,
                112 => 1150000,
                113 => 855000,
                114 => 745000,
                115 => 3000000,
                _ => 0,
            };
        }
        int func_5793(int iParam0)//Position - 0x1D72E8
        {
            return iParam0 switch
            {
                86 => 8,
                103 or 106 or 109 or 112 or 104 or 107 or 110 or 113 or 105 or 108 or 111 or 114 => 10,
                87 or 88 or 89 or 90 => 9,
                91 or 92 or 93 or 94 or 95 or 96 or 97 or 98 or 99 or 100 or 101 or 102 => 7,
                1 or 2 or 3 or 4 or 5 or 6 or 7 or 34 or 35 or 36 or 37 or 38 or 39 or 40 or 41 or 42 or 43 or 61 or 62 or 63 or 64 or 65 or 73 or 74 or 75 or 76 or 77 or 78 or 79 or 80 or 81 or 82 or 83 or 84 or 85 => 6,
                8 or 9 or 10 or 11 or 12 or 13 or 14 or 15 or 16 or 66 or 67 or 68 or 69 => 5,
                17 or 18 or 19 or 20 or 21 or 22 or 23 or 70 or 71 or 72 => 4,
                24 or 26 or 27 or 54 or 56 or 57 => 3,
                25 or 28 or 32 or 33 or 50 or 52 or 53 or 55 => 2,
                29 or 30 or 31 or 44 or 45 or 46 or 47 or 48 or 49 or 51 or 58 or 59 or 60 => 1,
                _ => 0,
            };
        }
        int func_7475(int iParam0)//Position - 0x27D057
        {
            return iParam0 switch
            {
                1 => 1,
                2 => 2,
                3 => 3,
                4 => 1,
                5 => 2,
                6 => 1,
                7 => 1,
                8 => 1,
                9 => 1,
                10 => 1,
                11 => 1,
                12 => 1,
                13 => 1,
                14 => 3,
                15 => 3,
                16 => 2,
                17 => 1,
                18 => 1,
                19 => 3,
                20 => 2,
                21 => 3,
                22 => 3,
                23 => 3,
                24 => 4,
                25 => 4,
                26 => 4,
                27 => 4,
                28 => 4,
                29 => 5,
                30 => 5,
                31 => 4,
                32 => 5,
                33 => 5,
                34 => 6,
                35 => 6,
                36 => 6,
                37 => 6,
                38 => 6,
                39 => 6,
                40 => 6,
                41 => 6,
                42 => 6,
                43 => 5,
                44 => 5,
                45 => 5,
                46 => 5,
                47 => 5,
                48 => 5,
                49 => 1,
                50 => 4,
                _ => 0,
            };
        }
        int func_67(int iParam0)//Position - 0x2239B
        {
            int iVar0;
            bool bVar1;
            string sVar2 = "";
            int iVar18;
            int iVar19;

            iVar0 = 0;
            bVar1 = false;
            if (func_5731(iParam0))
            {
                if (!func_5727(iParam0))
                {
                    iVar0 = 1;
                }
                else
                {
                    bVar1 = true;
                }
            }
            func_68(ref sVar2, iParam0, iVar0, bVar1);
            iVar18 = GetHashKey(sVar2);
            if (NetGameserverCatalogItemExistsHash((uint)iVar18))
            {
                iVar19 = NetGameserverGetPrice((uint)iVar18, (uint)GetHashKey("CATEGORY_PROPERTIE"), true);
                return iVar19;
            }

            return iParam0 switch
            {
                1 => Tunables.Global_262145.Value<int>("f_3960") /* Tunable: PROPERTY_HIGH_APT_1_EXPENDITURE_MODIFIER */,
                2 => Tunables.Global_262145.Value<int>("f_3961") /* Tunable: PROPERTY_HIGH_APT_2_EXPENDITURE_MODIFIER */,
                3 => Tunables.Global_262145.Value<int>("f_3962") /* Tunable: PROPERTY_HIGH_APT_3_EXPENDITURE_MODIFIER */,
                4 => Tunables.Global_262145.Value<int>("f_3963") /* Tunable: PROPERTY_HIGH_APT_4_EXPENDITURE_MODIFIER */,
                5 => Tunables.Global_262145.Value<int>("f_3964") /* Tunable: PROPERTY_HIGH_APT_5_EXPENDITURE_MODIFIER */,
                6 => Tunables.Global_262145.Value<int>("f_3965") /* Tunable: PROPERTY_HIGH_APT_6_EXPENDITURE_MODIFIER */,
                7 => Tunables.Global_262145.Value<int>("f_3966") /* Tunable: PROPERTY_HIGH_APT_7_EXPENDITURE_MODIFIER */,
                34 => Tunables.Global_262145.Value<int>("f_3967") /* Tunable: PROPERTY_HIGH_APT_8_EXPENDITURE_MODIFIER */,
                35 => Tunables.Global_262145.Value<int>("f_3968") /* Tunable: PROPERTY_HIGH_APT_9_EXPENDITURE_MODIFIER */,
                36 => Tunables.Global_262145.Value<int>("f_3969") /* Tunable: PROPERTY_HIGH_APT_10_EXPENDITURE_MODIFIER */,
                37 => Tunables.Global_262145.Value<int>("f_3970") /* Tunable: PROPERTY_HIGH_APT_11_EXPENDITURE_MODIFIER */,
                38 => Tunables.Global_262145.Value<int>("f_3971") /* Tunable: PROPERTY_HIGH_APT_12_EXPENDITURE_MODIFIER */,
                39 => Tunables.Global_262145.Value<int>("f_3972") /* Tunable: PROPERTY_HIGH_APT_13_EXPENDITURE_MODIFIER */,
                40 => Tunables.Global_262145.Value<int>("f_3973") /* Tunable: PROPERTY_HIGH_APT_14_EXPENDITURE_MODIFIER */,
                41 => Tunables.Global_262145.Value<int>("f_3974") /* Tunable: PROPERTY_HIGH_APT_15_EXPENDITURE_MODIFIER */,
                42 => Tunables.Global_262145.Value<int>("f_3975") /* Tunable: PROPERTY_HIGH_APT_16_EXPENDITURE_MODIFIER */,
                43 => Tunables.Global_262145.Value<int>("f_3976") /* Tunable: PROPERTY_HIGH_APT_17_EXPENDITURE_MODIFIER */,
                8 => Tunables.Global_262145.Value<int>("f_3977") /* Tunable: PROPERTY_MEDIUM_APT_1_EXPENDITURE_MODIFIER */,
                9 => Tunables.Global_262145.Value<int>("f_3978") /* Tunable: PROPERTY_MEDIUM_APT_2_EXPENDITURE_MODIFIER */,
                10 => Tunables.Global_262145.Value<int>("f_3979") /* Tunable: PROPERTY_MEDIUM_APT_3_EXPENDITURE_MODIFIER */,
                11 => Tunables.Global_262145.Value<int>("f_3980") /* Tunable: PROPERTY_MEDIUM_APT_4_EXPENDITURE_MODIFIER */,
                12 => Tunables.Global_262145.Value<int>("f_3981") /* Tunable: PROPERTY_MEDIUM_APT_5_EXPENDITURE_MODIFIER */,
                13 => Tunables.Global_262145.Value<int>("f_3982") /* Tunable: PROPERTY_MEDIUM_APT_6_EXPENDITURE_MODIFIER */,
                14 => Tunables.Global_262145.Value<int>("f_3983") /* Tunable: PROPERTY_MEDIUM_APT_7_EXPENDITURE_MODIFIER */,
                15 => Tunables.Global_262145.Value<int>("f_3984") /* Tunable: PROPERTY_MEDIUM_APT_8_EXPENDITURE_MODIFIER */,
                16 => Tunables.Global_262145.Value<int>("f_3985") /* Tunable: PROPERTY_MEDIUM_APT_9_EXPENDITURE_MODIFIER */,
                17 => Tunables.Global_262145.Value<int>("f_3986") /* Tunable: PROPERTY_LOW_APT_1_EXPENDITURE_MODIFIER */,
                18 => Tunables.Global_262145.Value<int>("f_3987") /* Tunable: PROPERTY_LOW_APT_2_EXPENDITURE_MODIFIER */,
                19 => Tunables.Global_262145.Value<int>("f_3988") /* Tunable: PROPERTY_LOW_APT_3_EXPENDITURE_MODIFIER */,
                20 => Tunables.Global_262145.Value<int>("f_3989") /* Tunable: PROPERTY_LOW_APT_4_EXPENDITURE_MODIFIER */,
                21 => Tunables.Global_262145.Value<int>("f_3990") /* Tunable: PROPERTY_LOW_APT_5_EXPENDITURE_MODIFIER */,
                22 => Tunables.Global_262145.Value<int>("f_3991") /* Tunable: PROPERTY_LOW_APT_6_EXPENDITURE_MODIFIER */,
                23 => Tunables.Global_262145.Value<int>("f_3992") /* Tunable: PROPERTY_LOW_APT_7_EXPENDITURE_MODIFIER */,
                24 => Tunables.Global_262145.Value<int>("f_3993") /* Tunable: PROPERTY_GARAGE_EAST_LOS_SANTOS_1_EXPENDITURE_MODIFIER */,
                25 => Tunables.Global_262145.Value<int>("f_3994") /* Tunable: PROPERTY_GARAGE_EAST_LOS_SANTOS_2_EXPENDITURE_MODIFIER */,
                26 => Tunables.Global_262145.Value<int>("f_3995") /* Tunable: PROPERTY_GARAGE_EAST_LOS_SANTOS_3_EXPENDITURE_MODIFIER */,
                27 => Tunables.Global_262145.Value<int>("f_3996") /* Tunable: PROPERTY_GARAGE_EAST_LOS_SANTOS_4_EXPENDITURE_MODIFIER */,
                28 => Tunables.Global_262145.Value<int>("f_3997") /* Tunable: PROPERTY_GARAGE_EAST_LOS_SANTOS_5_EXPENDITURE_MODIFIER */,
                29 => Tunables.Global_262145.Value<int>("f_3998") /* Tunable: PROPERTY_GARAGE_EAST_LOS_SANTOS_6_EXPENDITURE_MODIFIER */,
                30 => Tunables.Global_262145.Value<int>("f_3999") /* Tunable: PROPERTY_GARAGE_EAST_LOS_SANTOS_7_EXPENDITURE_MODIFIER */,
                31 => Tunables.Global_262145.Value<int>("f_4000") /* Tunable: PROPERTY_GARAGE_EAST_LOS_SANTOS_8_EXPENDITURE_MODIFIER */,
                32 => Tunables.Global_262145.Value<int>("f_4001") /* Tunable: PROPERTY_GARAGE_SOUTH_LOS_SANTOS_1_EXPENDITURE_MODIFIER */,
                33 => Tunables.Global_262145.Value<int>("f_4002") /* Tunable: PROPERTY_GARAGE_SOUTH_LOS_SANTOS_2_EXPENDITURE_MODIFIER */,
                44 => Tunables.Global_262145.Value<int>("f_4003") /* Tunable: PROPERTY_GARAGE_NEW_1_EXPENDITURE_MODIFIER */,
                45 => Tunables.Global_262145.Value<int>("f_4004") /* Tunable: PROPERTY_GARAGE_NEW_2_EXPENDITURE_MODIFIER */,
                46 => Tunables.Global_262145.Value<int>("f_4005") /* Tunable: PROPERTY_GARAGE_NEW_3_EXPENDITURE_MODIFIER */,
                47 => Tunables.Global_262145.Value<int>("f_4006") /* Tunable: PROPERTY_GARAGE_NEW_5_EXPENDITURE_MODIFIER */,
                48 => Tunables.Global_262145.Value<int>("f_4007") /* Tunable: PROPERTY_GARAGE_NEW_6_EXPENDITURE_MODIFIER */,
                49 => Tunables.Global_262145.Value<int>("f_4008") /* Tunable: PROPERTY_GARAGE_NEW_7_EXPENDITURE_MODIFIER */,
                50 => Tunables.Global_262145.Value<int>("f_4009") /* Tunable: PROPERTY_GARAGE_NEW_8_EXPENDITURE_MODIFIER */,
                51 => Tunables.Global_262145.Value<int>("f_4010") /* Tunable: PROPERTY_GARAGE_NEW_9_EXPENDITURE_MODIFIER */,
                52 => Tunables.Global_262145.Value<int>("f_4011") /* Tunable: PROPERTY_GARAGE_NEW_14_EXPENDITURE_MODIFIER */,
                53 => Tunables.Global_262145.Value<int>("f_4012") /* Tunable: PROPERTY_GARAGE_NEW_16_EXPENDITURE_MODIFIER */,
                54 => Tunables.Global_262145.Value<int>("f_4013") /* Tunable: PROPERTY_GARAGE_NEW_17_EXPENDITURE_MODIFIER */,
                55 => Tunables.Global_262145.Value<int>("f_4014") /* Tunable: PROPERTY_GARAGE_NEW_18_EXPENDITURE_MODIFIER */,
                56 => Tunables.Global_262145.Value<int>("f_4015") /* Tunable: PROPERTY_GARAGE_NEW_19_EXPENDITURE_MODIFIER */,
                57 => Tunables.Global_262145.Value<int>("f_4016") /* Tunable: PROPERTY_GARAGE_NEW_20_EXPENDITURE_MODIFIER */,
                58 => Tunables.Global_262145.Value<int>("f_4017") /* Tunable: PROPERTY_GARAGE_NEW_21_EXPENDITURE_MODIFIER */,
                59 => Tunables.Global_262145.Value<int>("f_4018") /* Tunable: PROPERTY_GARAGE_NEW_22_EXPENDITURE_MODIFIER */,
                60 => Tunables.Global_262145.Value<int>("f_4019") /* Tunable: PROPERTY_GARAGE_NEW_23_EXPENDITURE_MODIFIER */,
                61 => Tunables.Global_262145.Value<JArray>("f_7146").ToObject<List<int>>()[0],
                62 => Tunables.Global_262145.Value<JArray>("f_7146").ToObject<List<int>>()[1],
                63 => Tunables.Global_262145.Value<JArray>("f_7146").ToObject<List<int>>()[2],
                64 => Tunables.Global_262145.Value<JArray>("f_7146").ToObject<List<int>>()[3],
                65 => Tunables.Global_262145.Value<JArray>("f_7146").ToObject<List<int>>()[4],
                66 => Tunables.Global_262145.Value<int>("f_8461") /* Tunable: PROPERTY_3_ACE_JONES_DR */,
                67 => Tunables.Global_262145.Value<int>("f_8462") /* Tunable: PROPERTY_12_SUSTANCIA_RD */,
                68 => Tunables.Global_262145.Value<int>("f_8463") /* Tunable: PROPERTY_4584_PROCOPIO_DR */,
                69 => Tunables.Global_262145.Value<int>("f_8464") /* Tunable: PROPERTY_4401_PROCOPIO_DR */,
                70 => Tunables.Global_262145.Value<int>("f_8465") /* Tunable: PROPERTY_0232_PALETO_BLVD */,
                71 => Tunables.Global_262145.Value<int>("f_8466") /* Tunable: PROPERTY_140_ZANCUDO_AVE */,
                72 => Tunables.Global_262145.Value<int>("f_8467") /* Tunable: PROPERTY_1893_GRAPESEED_AVE */,
                73 => Tunables.Global_262145.Value<int>("f_13488") /* Tunable: APARTMENT_CAR_MODSSTILT_3655_WILD_OATS_DRIVE */,
                74 => Tunables.Global_262145.Value<int>("f_13489") /* Tunable: APARTMENT_CAR_MODSSTILT_2044_NORTH_CONKER_AVENUE */,
                75 => Tunables.Global_262145.Value<int>("f_13490") /* Tunable: APARTMENT_CAR_MODSSTILT_2868_HILLCREST_AVENUE */,
                76 => Tunables.Global_262145.Value<int>("f_13491") /* Tunable: APARTMENT_CAR_MODSSTILT_2862_HILLCREST_AVENUE */,
                77 => Tunables.Global_262145.Value<int>("f_13492") /* Tunable: APARTMENT_CAR_MODSSTILT_3677_WHISPYMOUND_DRIVE */,
                78 => Tunables.Global_262145.Value<int>("f_13493") /* Tunable: APARTMENT_CAR_MODSSTILT_2117_MILTON_ROAD */,
                79 => Tunables.Global_262145.Value<int>("f_13494") /* Tunable: APARTMENT_CAR_MODSSTILT_2866_HILLCREST_AVENUE */,
                80 => Tunables.Global_262145.Value<int>("f_13495") /* Tunable: APARTMENT_CAR_MODSSTILT_2874_HILLCREST_AVENUE */,
                81 => Tunables.Global_262145.Value<int>("f_13496") /* Tunable: APARTMENT_CAR_MODSSTILT_2113_MAD_WAYNE_THUNDER_DRIVE */,
                82 => Tunables.Global_262145.Value<int>("f_13497") /* Tunable: APARTMENT_CAR_MODSSTILT_2045_NORTH_CONKER_AVENUE */,
                83 => Tunables.Global_262145.Value<int>("f_13485") /* Tunable: APARTMENT_CAR_MODSECLIPSE_TOWERS_PENTHOUSE_SUITE_1 */,
                84 => Tunables.Global_262145.Value<int>("f_13486") /* Tunable: APARTMENT_CAR_MODSECLIPSE_TOWERS_PENTHOUSE_SUITE_2 */,
                85 => Tunables.Global_262145.Value<int>("f_13487") /* Tunable: APARTMENT_CAR_MODSECLIPSE_TOWERS_PENTHOUSE_SUITE_3 */,
                86 => 27000000,
                87 => Tunables.Global_262145.Value<int>("f_16072") /* Tunable: EXEC1_OFFICE1_LOMBANK */,
                88 => Tunables.Global_262145.Value<int>("f_16073") /* Tunable: EXEC1_OFFICE2_MAZE1 */,
                89 => Tunables.Global_262145.Value<int>("f_16074") /* Tunable: EXEC1_OFFICE3_ARCADIUS */,
                90 => Tunables.Global_262145.Value<int>("f_16075") /* Tunable: EXEC1_OFFICE4_MAZE2 */,
                91 => Tunables.Global_262145.Value<int>("f_18167") /* Tunable: 819519215 */,
                92 => Tunables.Global_262145.Value<int>("f_18169") /* Tunable: 471352940 */,
                93 => Tunables.Global_262145.Value<int>("f_18165") /* Tunable: 2023136086 */,
                94 => Tunables.Global_262145.Value<int>("f_18174") /* Tunable: 217858651 */,
                95 => Tunables.Global_262145.Value<int>("f_18171") /* Tunable: -1058611921 */,
                96 => Tunables.Global_262145.Value<int>("f_18173") /* Tunable: -1767762009 */,
                97 => Tunables.Global_262145.Value<int>("f_18166") /* Tunable: -1390109608 */,
                98 => Tunables.Global_262145.Value<int>("f_18164") /* Tunable: 2033735347 */,
                99 => Tunables.Global_262145.Value<int>("f_18163") /* Tunable: -1219608517 */,
                100 => Tunables.Global_262145.Value<int>("f_18172") /* Tunable: 1669688233 */,
                101 => Tunables.Global_262145.Value<int>("f_18170") /* Tunable: 1241258301 */,
                102 => Tunables.Global_262145.Value<int>("f_18168") /* Tunable: 813618473 */,
                103 => Tunables.Global_262145.Value<int>("f_19835") /* Tunable: IMPEXP_GARAGE_LEVEL1 */,
                104 => Tunables.Global_262145.Value<int>("f_19728") /* Tunable: IMPEXP_GARAGE_LEVEL2_COST */,
                105 => Tunables.Global_262145.Value<int>("f_19729") /* Tunable: IMPEXP_GARAGE_LEVEL3_COST */,
                106 => Tunables.Global_262145.Value<int>("f_19835") /* Tunable: IMPEXP_GARAGE_LEVEL1 */,
                107 => Tunables.Global_262145.Value<int>("f_19728") /* Tunable: IMPEXP_GARAGE_LEVEL2_COST */,
                108 => Tunables.Global_262145.Value<int>("f_19729") /* Tunable: IMPEXP_GARAGE_LEVEL3_COST */,
                109 => Tunables.Global_262145.Value<int>("f_19835") /* Tunable: IMPEXP_GARAGE_LEVEL1 */,
                110 => Tunables.Global_262145.Value<int>("f_19728") /* Tunable: IMPEXP_GARAGE_LEVEL2_COST */,
                111 => Tunables.Global_262145.Value<int>("f_19729") /* Tunable: IMPEXP_GARAGE_LEVEL3_COST */,
                112 => Tunables.Global_262145.Value<int>("f_19835") /* Tunable: IMPEXP_GARAGE_LEVEL1 */,
                113 => Tunables.Global_262145.Value<int>("f_19728") /* Tunable: IMPEXP_GARAGE_LEVEL2_COST */,
                114 => Tunables.Global_262145.Value<int>("f_19729") /* Tunable: IMPEXP_GARAGE_LEVEL3_COST */,
                115 => 3000000,
                _ => 0,
            };
        }

        void func_68(ref string sParam0, int iParam1, int iParam2, bool bParam3)//Position - 0x22C36
        {

            //StringCopy(sParam0, "FACTORY_INDEX_", 64);
            string Var0 = func_66(iParam1);
            sParam0 = $"PR_{Var0}_t0_v{iParam2}{(bParam3 ? "_CESP" : "")}";
        }
        string func_66(int iParam0)//Position - 0x21C48
        {

            string Var0 = "";

            switch (iParam0)
            {
                case 1:
                    Var0 = "MP_PROP_1" /* GXT: Eclipse Towers, Apt 31 */;
                    break;

                case 2:
                    Var0 = "MP_PROP_2" /* GXT: Eclipse Towers, Apt 9 */;
                    break;

                case 3:
                    Var0 = "MP_PROP_3" /* GXT: Eclipse Towers, Apt 40 */;
                    break;

                case 4:
                    Var0 = "MP_PROP_4" /* GXT: Eclipse Towers, Apt 5 */;
                    break;

                case 5:
                    Var0 = "MP_PROP_5" /* GXT: 3 Alta St, Apt 10 */;
                    break;

                case 6:
                    Var0 = "MP_PROP_6" /* GXT: 3 Alta St, Apt 57 */;
                    break;

                case 7:
                    Var0 = "MP_PROP_7" /* GXT: Del Perro Heights, Apt 20 */;
                    break;

                case 8:
                    Var0 = "MP_PROP_8" /* GXT: 1162 Power St, Apt 3 */;
                    break;

                case 9:
                    Var0 = "MP_PROP_9" /* GXT: 0605 Spanish Ave, Apt 1 */;
                    break;

                case 10:
                    Var0 = "MP_PROP_10" /* GXT: 0604 Las Lagunas Blvd, Apt 4 */;
                    break;

                case 11:
                    Var0 = "MP_PROP_11" /* GXT: 0184 Milton Rd, Apt 13 */;
                    break;

                case 12:
                    Var0 = "MP_PROP_12" /* GXT: The Royale, Apt 19 */;
                    break;

                case 13:
                    Var0 = "MP_PROP_13" /* GXT: 0504 S Mo Milton Dr */;
                    break;

                case 14:
                    Var0 = "MP_PROP_14" /* GXT: 0115 Bay City Ave, Apt 45 */;
                    break;

                case 15:
                    Var0 = "MP_PROP_15" /* GXT: 0325 South Rockford Dr */;
                    break;

                case 16:
                    Var0 = "MP_PROP_16" /* GXT: Dream Tower, Apt 15 */;
                    break;

                case 17:
                    Var0 = "MP_PROP_17" /* GXT: 2143 Las Lagunas Blvd, Apt 9 */;
                    break;

                case 18:
                    Var0 = "MP_PROP_18" /* GXT: 1561 San Vitas St, Apt 2 */;
                    break;

                case 19:
                    Var0 = "MP_PROP_19" /* GXT: 0112 S Rockford Dr, Apt 13 */;
                    break;

                case 20:
                    Var0 = "MP_PROP_20" /* GXT: 2057 Vespucci Blvd, Apt 1 */;
                    break;

                case 21:
                    Var0 = "MP_PROP_21" /* GXT: 0069 Cougar Ave, Apt 19 */;
                    break;

                case 22:
                    Var0 = "MP_PROP_22" /* GXT: 1237 Prosperity St, Apt 21 */;
                    break;

                case 23:
                    Var0 = "MP_PROP_23" /* GXT: 1115 Blvd Del Perro, Apt 18 */;
                    break;

                case 24:
                    Var0 = "MP_PROP_24" /* GXT: 0120 Murrieta Heights */;
                    break;

                case 25:
                    Var0 = "MP_PROP_25" /* GXT: Unit 14 Popular St */;
                    break;

                case 26:
                    Var0 = "MP_PROP_26" /* GXT: Unit 2 Popular St */;
                    break;

                case 27:
                    Var0 = "MP_PROP_27" /* GXT: 331 Supply St */;
                    break;

                case 28:
                    Var0 = "MP_PROP_28" /* GXT: Unit 1 Olympic Fwy */;
                    break;

                case 29:
                    Var0 = "MP_PROP_29" /* GXT: 0754 Roy Lowenstein Blvd */;
                    break;

                case 30:
                    Var0 = "MP_PROP_30" /* GXT: 12 Little Bighorn Ave */;
                    break;

                case 31:
                    Var0 = "MP_PROP_31" /* GXT: Unit 124 Popular St */;
                    break;

                case 32:
                    Var0 = "MP_PROP_32" /* GXT: 0552 Roy Lowenstein Blvd */;
                    break;

                case 33:
                    Var0 = "MP_PROP_33" /* GXT: 0432 Davis Ave */;
                    break;

                case 34:
                    Var0 = "MP_PROP_34" /* GXT: Del Perro Heights, Apt 7 */;
                    break;

                case 35:
                    Var0 = "MP_PROP_35" /* GXT: Weazel Plaza, Apt 101 */;
                    break;

                case 36:
                    Var0 = "MP_PROP_36" /* GXT: Weazel Plaza, Apt 70 */;
                    break;

                case 37:
                    Var0 = "MP_PROP_37" /* GXT: Weazel Plaza, Apt 26 */;
                    break;

                case 38:
                    Var0 = "MP_PROP_38" /* GXT: 4 Integrity Way, Apt 30 */;
                    break;

                case 39:
                    Var0 = "MP_PROP_39" /* GXT: 4 Integrity Way, Apt 35 */;
                    break;

                case 40:
                    Var0 = "MP_PROP_40" /* GXT: Richards Majestic, Apt 4 */;
                    break;

                case 41:
                    Var0 = "MP_PROP_41" /* GXT: Richards Majestic, Apt 51 */;
                    break;

                case 42:
                    Var0 = "MP_PROP_42" /* GXT: Tinsel Towers, Apt 45 */;
                    break;

                case 43:
                    Var0 = "MP_PROP_43" /* GXT: Tinsel Towers, Apt 29 */;
                    break;

                case 44:
                    Var0 = "MP_PROP_44" /* GXT: 142 Paleto Blvd */;
                    break;

                case 45:
                    Var0 = "MP_PROP_45" /* GXT: 1 Strawberry Ave */;
                    break;

                case 46:
                    Var0 = "MP_PROP_46" /* GXT: 1932 Grapeseed Ave */;
                    break;

                case 47:
                    Var0 = "MP_PROP_48" /* GXT: 1920 Senora Way */;
                    break;

                case 48:
                    Var0 = "MP_PROP_49" /* GXT: 2000 Great Ocean Highway */;
                    break;

                case 49:
                    Var0 = "MP_PROP_50" /* GXT: 197 Route 68 */;
                    break;

                case 50:
                    Var0 = "MP_PROP_51" /* GXT: 870 Route 68 Approach */;
                    break;

                case 51:
                    Var0 = "MP_PROP_52" /* GXT: 1200 Route 68 */;
                    break;

                case 52:
                    Var0 = "MP_PROP_57" /* GXT: 8754 Route 68 */;
                    break;

                case 53:
                    Var0 = "MP_PROP_59" /* GXT: 1905 Davis Ave */;
                    break;

                case 54:
                    Var0 = "MP_PROP_60" /* GXT: 1623 South Shambles St */;
                    break;

                case 55:
                    Var0 = "MP_PROP_61" /* GXT: 4531 Dry Dock St */;
                    break;

                case 56:
                    Var0 = "MP_PROP_62" /* GXT: 1337 Exceptionalists Way */;
                    break;

                case 57:
                    Var0 = "MP_PROP_63" /* GXT: Unit 76 Greenwich Parkway */;
                    break;

                case 58:
                    Var0 = "MP_PROP_64" /* GXT: Garage Innocence Blvd */;
                    break;

                case 59:
                    Var0 = "MP_PROP_65" /* GXT: 634 Blvd Del Perro */;
                    break;

                case 60:
                    Var0 = "MP_PROP_66" /* GXT: 0897 Mirror Park Blvd */;
                    break;

                case 61:
                    Var0 = "MP_PROP_67" /* GXT: Eclipse Towers, Apt 3 */;
                    break;

                case 62:
                    Var0 = "MP_PROP_68" /* GXT: Del Perro Heights, Apt 4 */;
                    break;

                case 63:
                    Var0 = "MP_PROP_69" /* GXT: Richards Majestic, Apt 2 */;
                    break;

                case 64:
                    Var0 = "MP_PROP_70" /* GXT: Tinsel Towers, Apt 42 */;
                    break;

                case 65:
                    Var0 = "MP_PROP_71" /* GXT: 4 Integrity Way, Apt 28 */;
                    break;

                case 66:
                    Var0 = "MP_PROP_72" /* GXT: 4 Hangman Ave */;
                    break;

                case 67:
                    Var0 = "MP_PROP_73" /* GXT: 12 Sustancia Rd */;
                    break;

                case 68:
                    Var0 = "MP_PROP_74" /* GXT: 4584 Procopio Dr */;
                    break;

                case 69:
                    Var0 = "MP_PROP_75" /* GXT: 4401 Procopio Dr */;
                    break;

                case 70:
                    Var0 = "MP_PROP_76" /* GXT: 0232 Paleto Blvd */;
                    break;

                case 71:
                    Var0 = "MP_PROP_77" /* GXT: 140 Zancudo Ave */;
                    break;

                case 72:
                    Var0 = "MP_PROP_78" /* GXT: 1893 Grapeseed Ave */;
                    break;

                case 83:
                    Var0 = "MP_PROP_79" /* GXT: Eclipse Towers, Penthouse Suite 1 */;
                    break;

                case 84:
                    Var0 = "MP_PROP_80" /* GXT: Eclipse Towers, Penthouse Suite 2 */;
                    break;

                case 85:
                    Var0 = "MP_PROP_81" /* GXT: Eclipse Towers, Penthouse Suite 3 */;
                    break;

                case 73:
                    Var0 = "MP_PROP_83" /* GXT: 3655 Wild Oats Drive */;
                    break;

                case 74:
                    Var0 = "MP_PROP_84" /* GXT: 2044 North Conker Avenue */;
                    break;

                case 75:
                    Var0 = "MP_PROP_85" /* GXT: 2868 Hillcrest Avenue */;
                    break;

                case 76:
                    Var0 = "MP_PROP_86" /* GXT: 2862 Hillcrest Avenue */;
                    break;

                case 77:
                    Var0 = "MP_PROP_87" /* GXT: 3677 Whispymound Drive */;
                    break;

                case 78:
                    Var0 = "MP_PROP_89" /* GXT: 2117 Milton Road */;
                    break;

                case 79:
                    Var0 = "MP_PROP_90" /* GXT: 2866 Hillcrest Avenue */;
                    break;

                case 80:
                    Var0 = "MP_PROP_92" /* GXT: 2874 Hillcrest Avenue */;
                    break;

                case 81:
                    Var0 = "MP_PROP_94" /* GXT: 2113 Mad Wayne Thunder Drive */;
                    break;

                case 82:
                    Var0 = "MP_PROP_95" /* GXT: 2045 North Conker Avenue */;
                    break;

                case 86:
                    Var0 = "PM_SPAWN_Y" /* GXT: Private Yacht */;
                    break;

                case 87:
                    Var0 = "MP_PROP_OFF1" /* GXT: Lombank West */;
                    break;

                case 88:
                    Var0 = "MP_PROP_OFF2" /* GXT: Maze Bank West */;
                    break;

                case 89:
                    Var0 = "MP_PROP_OFF3" /* GXT: Arcadius Business Center */;
                    break;

                case 90:
                    Var0 = "MP_PROP_OFF4" /* GXT: Maze Bank Tower */;
                    break;

                case 91:
                    Var0 = "MP_PROP_CLUBH1" /* GXT: Rancho Clubhouse */;
                    break;

                case 92:
                    Var0 = "MP_PROP_CLUBH2" /* GXT: Del Perro Beach Clubhouse */;
                    break;

                case 93:
                    Var0 = "MP_PROP_CLUBH3" /* GXT: Pillbox Hill Clubhouse */;
                    break;

                case 94:
                    Var0 = "MP_PROP_CLUBH4" /* GXT: Great Chaparral Clubhouse */;
                    break;

                case 95:
                    Var0 = "MP_PROP_CLUBH5" /* GXT: Paleto Bay Clubhouse */;
                    break;

                case 96:
                    Var0 = "MP_PROP_CLUBH6" /* GXT: Sandy Shores Clubhouse */;
                    break;

                case 97:
                    Var0 = "MP_PROP_CLUBH7" /* GXT: La Mesa Clubhouse */;
                    break;

                case 98:
                    Var0 = "MP_PROP_CLUBH8" /* GXT: Downtown Vinewood Clubhouse */;
                    break;

                case 99:
                    Var0 = "MP_PROP_CLUBH9" /* GXT: Hawick Clubhouse */;
                    break;

                case 100:
                    Var0 = "MP_PROP_CLUBH10" /* GXT: Grapeseed Clubhouse */;
                    break;

                case 101:
                    Var0 = "MP_PROP_CLUBH11" /* GXT: Paleto Bay Clubhouse */;
                    break;

                case 102:
                    Var0 = "MP_PROP_CLUBH12" /* GXT: Vespucci Beach Clubhouse */;
                    break;

                case 103:
                case 106:
                case 109:
                case 112:
                    Var0 = "MP_PROP_OFFG1" /* GXT: Office Garage 1 */;
                    break;

                case 104:
                case 107:
                case 110:
                case 113:
                    Var0 = "MP_PROP_OFFG2" /* GXT: Office Garage 2 */;
                    break;

                case 105:
                case 108:
                case 111:
                case 114:
                    Var0 = "MP_PROP_OFFG3" /* GXT: Office Garage 3 */;
                    break;

                case 115:
                    Var0 = "IE_WARE_1" /* GXT: Vehicle Warehouse */;
                    break;
            }
            return Var0;
        }
        int func_35(int iParam0)//Position - 0x44D2
        {
            return iParam0 switch
            {
                1 or 2 or 3 or 4 or 61 or 83 or 84 or 85 => 1,
                5 or 6 => 2,
                7 or 34 or 62 => 3,
                35 or 36 or 37 => 4,
                38 or 39 or 65 => 5,
                40 or 41 or 63 => 6,
                42 or 43 or 64 => 7,
                8 => 8,
                9 => 9,
                10 => 10,
                11 => 11,
                12 => 12,
                13 => 13,
                14 => 14,
                15 => 15,
                16 => 16,
                17 => 17,
                18 => 18,
                19 => 19,
                20 => 20,
                21 => 21,
                22 => 22,
                23 => 23,
                24 => 24,
                25 => 25,
                26 => 26,
                27 => 27,
                28 => 28,
                29 => 29,
                30 => 30,
                31 => 31,
                32 => 32,
                33 => 33,
                44 => 34,
                45 => 35,
                46 => 36,
                47 => 37,
                48 => 38,
                49 => 39,
                50 => 40,
                51 => 41,
                52 => 42,
                53 => 43,
                54 => 44,
                55 => 45,
                56 => 46,
                57 => 47,
                58 => 48,
                59 => 49,
                60 => 50,
                66 => 51,
                67 => 52,
                68 => 53,
                69 => 54,
                70 => 55,
                71 => 56,
                72 => 57,
                73 => 58,
                74 => 59,
                75 => 60,
                76 => 61,
                77 => 62,
                78 => 63,
                79 => 64,
                80 => 65,
                81 => 66,
                82 => 67,
                87 or 103 or 104 or 105 => 68,
                88 or 106 or 107 or 108 => 69,
                89 or 109 or 110 or 111 => 70,
                90 or 112 or 113 or 114 => 71,
                91 => 72,
                92 => 73,
                93 => 74,
                94 => 75,
                95 => 76,
                96 => 77,
                97 => 78,
                98 => 79,
                99 => 80,
                100 => 81,
                101 => 82,
                102 => 83,
                _ => 0,
            };
        }


        Vector3 GetDefaultPosition(int id)
        {
            int subId = 0;
            Vector3 position = Vector3.Zero;
            switch (id)
            {
                case 1:
                    subId = 1;
                    func_53(ref position, subId);
                    break;

                case 2:
                    subId = 1;
                    func_53(ref position, subId);
                    break;

                case 3:
                    subId = 1;
                    func_53(ref position, subId);
                    break;

                case 4:
                    subId = 1;
                    func_53(ref position, subId);
                    break;

                case 61:
                    subId = 1;
                    func_53(ref position, subId);
                    break;

                case 87:
                    subId = 68;
                    func_53(ref position, subId);
                    break;

                case 88:
                    subId = 69;
                    func_53(ref position, subId);
                    break;

                case 89:
                    subId = 70;
                    func_53(ref position, subId);
                    break;

                case 90:
                    subId = 71;
                    func_53(ref position, subId);
                    break;

                case 5:
                    subId = 2;
                    func_53(ref position, subId);
                    break;

                case 6:
                    subId = 2;
                    func_53(ref position, subId);
                    break;

                case 7:
                    subId = 3;
                    func_53(ref position, subId);
                    break;

                case 34:
                    subId = 3;
                    func_53(ref position, subId);
                    break;

                case 62:
                    subId = 3;
                    func_53(ref position, subId);
                    break;

                case 35:
                    subId = 4;
                    func_53(ref position, subId);
                    break;

                case 36:
                    subId = 4;
                    func_53(ref position, subId);
                    break;

                case 37:
                    subId = 4;
                    func_53(ref position, subId);
                    break;

                case 38:
                    subId = 5;
                    func_53(ref position, subId);
                    break;

                case 39:
                    subId = 5;
                    func_53(ref position, subId);
                    break;

                case 65:
                    subId = 5;
                    func_53(ref position, subId);
                    break;

                case 40:
                    subId = 6;
                    func_53(ref position, subId);
                    break;

                case 41:
                    subId = 6;
                    func_53(ref position, subId);
                    break;

                case 63:
                    subId = 6;
                    func_53(ref position, subId);
                    break;

                case 42:
                    subId = 7;
                    func_53(ref position, subId);
                    break;

                case 43:
                    subId = 7;
                    func_53(ref position, subId);
                    break;

                case 64:
                    subId = 7;
                    func_53(ref position, subId);
                    break;

                case 73:
                    subId = func_35(Id);
                    func_53(ref position, subId);
                    break;

                case 74:
                    subId = func_35(Id);
                    func_53(ref position, subId);
                    break;

                case 75:
                    subId = func_35(Id);
                    func_53(ref position, subId);
                    break;

                case 76:
                    subId = func_35(Id);
                    func_53(ref position, subId);
                    break;

                case 77:
                    subId = func_35(Id);
                    func_53(ref position, subId);
                    break;

                case 78:
                    subId = func_35(Id);
                    func_53(ref position, subId);
                    break;

                case 79:
                    subId = func_35(Id);
                    func_53(ref position, subId);
                    break;

                case 80:
                    subId = func_35(Id);
                    func_53(ref position, subId);
                    break;

                case 81:
                    subId = func_35(Id);
                    func_53(ref position, subId);
                    break;

                case 82:
                    subId = func_35(Id);
                    func_53(ref position, subId);
                    break;

                case 83:
                    subId = func_35(Id);
                    func_53(ref position, subId);
                    break;

                case 84:
                    subId = func_35(Id);
                    func_53(ref position, subId);
                    break;

                case 85:
                    subId = func_35(Id);
                    func_53(ref position, subId);
                    break;

                case 8:
                    subId = 8;
                    func_53(ref position, subId);
                    break;

                case 9:
                    subId = 9;
                    func_53(ref position, subId);
                    break;

                case 10:
                    subId = 10;
                    func_53(ref position, subId);
                    break;

                case 11:
                    subId = 11;
                    func_53(ref position, subId);
                    break;

                case 12:
                    subId = 12;
                    func_53(ref position, subId);
                    break;

                case 13:
                    subId = 13;
                    func_53(ref position, subId);
                    break;

                case 14:
                    subId = 14;
                    func_53(ref position, subId);
                    break;

                case 15:
                    subId = 15;
                    func_53(ref position, subId);
                    break;

                case 16:
                    subId = 16;
                    func_53(ref position, subId);
                    break;

                case 17:
                    subId = 17;
                    func_53(ref position, subId);
                    break;

                case 18:
                    subId = 18;
                    func_53(ref position, subId);
                    break;

                case 19:
                    subId = 19;
                    func_53(ref position, subId);
                    break;

                case 20:
                    subId = 20;
                    func_53(ref position, subId);
                    break;

                case 21:
                    subId = 21;
                    func_53(ref position, subId);
                    break;

                case 22:
                    subId = 22;
                    func_53(ref position, subId);
                    break;

                case 23:
                    subId = 23;
                    func_53(ref position, subId);
                    break;

                case 24:
                    subId = 24;
                    func_53(ref position, subId);
                    break;

                case 25:
                    subId = 25;
                    func_53(ref position, subId);
                    break;

                case 26:
                    subId = 26;
                    func_53(ref position, subId);
                    break;

                case 27:
                    subId = 27;
                    func_53(ref position, subId);
                    break;

                case 28:
                    subId = 28;
                    func_53(ref position, subId);
                    break;

                case 29:
                    subId = 29;
                    func_53(ref position, subId);
                    break;

                case 30:
                    subId = 30;
                    func_53(ref position, subId);
                    break;

                case 31:
                    subId = 31;
                    func_53(ref position, subId);
                    break;

                case 32:
                    subId = 32;
                    func_53(ref position, subId);
                    break;

                case 33:
                    subId = 33;
                    func_53(ref position, subId);
                    break;

                case 44:
                    subId = 34;
                    func_53(ref position, subId);
                    break;

                case 45:
                    subId = 35;
                    func_53(ref position, subId);
                    break;

                case 46:
                    subId = 36;
                    func_53(ref position, subId);
                    break;

                case 47:
                    subId = 37;
                    func_53(ref position, subId);
                    break;

                case 48:
                    subId = 38;
                    func_53(ref position, subId);
                    break;

                case 49:
                    subId = 39;
                    func_53(ref position, subId);
                    break;

                case 50:
                    subId = 40;
                    func_53(ref position, subId);
                    break;

                case 51:
                    subId = 41;
                    func_53(ref position, subId);
                    break;

                case 52:
                    subId = 42;
                    func_53(ref position, subId);
                    break;

                case 53:
                    subId = 43;
                    func_53(ref position, subId);
                    break;

                case 54:
                    subId = 44;
                    func_53(ref position, subId);
                    break;

                case 55:
                    subId = 45;
                    func_53(ref position, subId);
                    break;

                case 56:
                    subId = 46;
                    func_53(ref position, subId);
                    break;

                case 57:
                    subId = 47;
                    func_53(ref position, subId);
                    break;

                case 58:
                    subId = 48;
                    func_53(ref position, subId);
                    break;

                case 59:
                    subId = 49;
                    func_53(ref position, subId);
                    break;

                case 60:
                    subId = 50;
                    func_53(ref position, subId);
                    break;

                case 66:
                    subId = 51;
                    func_53(ref position, subId);
                    break;

                case 67:
                    subId = 52;
                    func_53(ref position, subId);
                    break;

                case 68:
                    subId = 53;
                    func_53(ref position, subId);
                    break;

                case 69:
                    subId = 54;
                    func_53(ref position, subId);
                    break;

                case 70:
                    subId = 55;
                    func_53(ref position, subId);
                    break;
                case 71:
                    subId = 56;
                    func_53(ref position, subId);
                    break;

                case 72:
                    subId = 57;
                    func_53(ref position, subId);
                    break;
            }
            return position;
        }

        void func_53(ref Vector3 iParam0, int iParam1)
        {
            switch (iParam1)
            {
                case 1:
                    iParam0 = new(-773.6766f, 310.0611f, 84.6981f);
                    break;

                case 2:
                    iParam0 = new(-261.9f, -970.1f, 30.4f);
                    break;

                case 3:
                    iParam0 = new(-1443.0938f, -544.7684f, 33.7424f);
                    break;

                case 4:
                    iParam0 = new(-913.85f, -455.1392f, 38.5999f);
                    break;

                case 5:
                    iParam0 = new(-47.3145f, -585.9766f, 36.9593f);
                    break;

                case 6:
                    iParam0 = new(-932.8344f, -383.6555f, 37.9613f);
                    break;

                case 7:
                    iParam0 = new(-619.1315f, 37.8841f, 42.5883f);
                    break;

                case 8:
                    iParam0 = new(284.6026f, -160.2201f, 63.6221f);
                    break;

                case 9:
                    iParam0 = new(2.84f, 35.2876f, 70.5349f);
                    break;

                case 10:
                    iParam0 = new(10.4433f, 83.3155f, 77.3975f);
                    break;

                case 11:
                    iParam0 = new(-512.0948f, 110.6228f, 62.5925f);
                    break;

                case 12:
                    iParam0 = new(-197.516f, 87.9089f, 68.7457f);
                    break;

                case 13:
                    iParam0 = new(-628.8236f, 169.5813f, 60.1437f);
                    break;

                case 14:
                    iParam0 = new(-970.4616f, -1431.5524f, 6.6791f);
                    break;

                case 15:
                    iParam0 = new(-831.4647f, -861.3573f, 19.6944f);
                    break;

                case 16:
                    iParam0 = new(-762.0167f, -753.7158f, 26.8736f);
                    break;

                case 17:
                    iParam0 = new(-41.6451f, -58.4377f, 62.509f);
                    break;

                case 18:
                    iParam0 = new(-201.9074f, 186.2365f, 79.3279f);
                    break;

                case 19:
                    iParam0 = new(-813.1431f, -981.0231f, 13.1452f);
                    break;

                case 20:
                    iParam0 = new(-662.4317f, -853.6143f, 23.4561f);
                    break;

                case 21:
                    iParam0 = new(-1533.9158f, -326.4442f, 46.9108f);
                    break;

                case 22:
                    iParam0 = new(-1562.9495f, -406.2817f, 41.389f);
                    break;

                case 23:
                    iParam0 = new(-1606.781f, -431.8483f, 39.4372f);
                    break;

                case 24:
                    iParam0 = new(963.4199f, -1022.1301f, 39.8475f);
                    break;

                case 25:
                    iParam0 = new(895.9359f, -888.7846f, 26.2485f);
                    break;

                case 26:
                    iParam0 = new(817.4532f, -924.8551f, 25.243f);
                    break;

                case 27:
                    iParam0 = new(759.2387f, -755.3151f, 25.9151f);
                    break;

                case 28:
                    iParam0 = new(842.1298f, -1165.0754f, 24.3046f);
                    break;

                case 29:
                    iParam0 = new(528.8805f, -1603.0293f, 28.3225f);
                    break;

                case 30:
                    iParam0 = new(569.9441f, -1570.293f, 27.5777f);
                    break;

                case 31:
                    iParam0 = new(727.757f, -1189.8367f, 23.2765f);
                    break;

                case 32:
                    iParam0 = new(504.6782f, -1492.8872f, 28.2886f);
                    break;

                case 33:
                    iParam0 = new(475.7058f, -1547.1232f, 28.2828f);
                    break;

                case 34:
                case 35:
                case 36:
                case 37:
                case 38:
                case 39:
                case 40:
                case 41:
                case 42:
                case 43:
                case 44:
                case 45:
                case 46:
                case 47:
                case 48:
                case 49:
                case 50:
                case 51:
                case 52:
                case 53:
                case 54:
                case 55:
                case 56:
                case 57:
                case 58:
                case 59:
                case 60:
                case 61:
                case 62:
                case 63:
                case 64:
                case 65:
                case 66:
                case 67:
                    func_57(ref Position, iParam1);
                    break;

                case 68:
                case 69:
                case 70:
                case 71:
                    func_56(ref Position, iParam1);
                    break;

                case 72:
                case 73:
                case 74:
                case 75:
                case 76:
                case 77:
                case 78:
                case 79:
                case 80:
                case 81:
                case 82:
                case 83:
                    func_55(ref Position, iParam1);
                    break;
            }
        }
        void func_55(ref Vector3 position, int iParam1)//Position - 0x14594
        {
            switch (iParam1)
            {
                case 72:
                    position = new(254.0506f, -1809.112f, 26.2643f);
                    break;


                case 73:
                    position = new(-1471.8319f, -920.1343f, 9.0249f);
                    break;

                case 74:
                    position = new(37.272f, -1029.3018f, 28.5669f);
                    break;

                case 75:
                    position = new(46.7547f, 2789.6455f, 57.1054f);
                    break;

                case 76:
                    position = new(-342.0963f, 6065.6294f, 30.5093f);
                    break;

                case 77:
                    position = new(1737.9225f, 3709.1099f, 33.1355f);
                    break;

                case 78:
                    position = new(939.6351f, -1458.9806f, 30.47f);
                    break;

                case 79:
                    position = new(189.8949f, 309.2079f, 104.3896f);
                    break;

                case 80:
                    position = new(-22.0633f, -192.056f, 51.3638f);
                    break;

                case 81:
                    position = new(2471.9436f, 4110.662f, 37.0647f);
                    break;

                case 82:
                    position = new(-39.1115f, 6420.4746f, 30.6905f);
                    break;

                case 83:
                    position = new(-1134.7958f, -1568.8192f, 3.4081f);
                    break;
            }
        }

        void func_56(ref Vector3 position, int iParam1)//Position - 0x174D9
        {
            switch (iParam1)
            {
                case 68:
                    position = new(-1581.5f, -558.3f, 35f);
                    break;

                case 69:
                    position = new(-1370.3484f, -503.0963f, 32.1574f);
                    break;

                case 70:
                    position = new(-117.5296f, -605.7157f, 35.2857f);
                    break;

                case 71:
                    position = new(-81.3f, -797.5f, 44.2f);
                    break;
            }
        }

        void func_57(ref Vector3 position, int iParam1)//Position - 0x18AF4
        {
            switch (iParam1)
            {
                case 34:
                    position = new(-68.702f, 6426.148f, 30.439f);
                    break;

                case 35:
                    position = new(-245.5158f, 6239.048f, 30.4892f);
                    break;

                case 36:
                    position = new(2554.1653f, 4668.059f, 33.0233f);
                    break;

                case 37:
                    position = new(2461.2202f, 1589.2552f, 32.0443f);
                    break;

                case 38:
                    position = new(-2203.335f, 4244.4272f, 47.3305f);
                    break;

                case 39:
                    position = new(218.0665f, 2601.8171f, 44.7668f);
                    break;

                case 40:
                    position = new(186.1719f, 2786.3425f, 45.0144f);
                    break;

                case 41:
                    position = new(639.45f, 2771.2f, 41.2f);
                    break;

                case 42:
                    position = new(-1130.9376f, 2701.1333f, 17.8004f);
                    break;

                case 43:
                    position = new(-10.944f, -1646.7601f, 28.3125f);
                    break;

                case 44:
                    position = new(1024.2628f, -2398.4036f, 29.1261f);
                    break;

                case 45:
                    position = new(870.8577f, -2232.3228f, 29.5508f);
                    break;

                case 46:
                    position = new(-663.8541f, -2380.389f, 12.9446f);
                    break;

                case 47:
                    position = new(-1088.6158f, -2235.0977f, 12.2182f);
                    break;

                case 48:
                    position = new(-342.5126f, -1468.6746f, 29.6107f);
                    break;

                case 49:
                    position = new(-1241.5399f, -259.8841f, 37.9445f);
                    break;

                case 50:
                    position = new(899.8448f, -147.528f, 75.5674f);
                    break;

                case 51:
                    position = new(-1405.4109f, 526.8572f, 122.8361f);
                    break;

                case 52:
                    position = new(1336.8986f, -1578.7438f, 53.4443f);
                    break;

                case 53:
                    position = new(-104.9801f, 6529.1636f, 29.1719f);
                    break;

                case 54:
                    position = new(-302.6793f, 6327.531f, 31.8915f);
                    break;

                case 55:
                    position = new(-14.8944f, 6557.818f, 32.2454f);
                    break;

                case 56:
                    position = new(1898.9148f, 3781.8203f, 31.8819f);
                    break;

                case 57:
                    position = new(1663.0311f, 4776.304f, 41.0075f);
                    break;

                case 58:
                    position = new(-177.2919f, 504.2896f, 135.8602f);
                    break;

                case 59:
                    position = new(347.2768f, 442.0909f, 146.7065f);
                    break;

                case 60:
                    position = new(-753.4206f, 620.2255f, 141.8517f);
                    break;

                case 61:
                    position = new(-685.5753f, 595.7667f, 143.0528f);
                    break;

                case 62:
                    position = new(118.1757f, 563.7846f, 182.9644f);
                    break;

                case 63:
                    position = new(-559.6165f, 663.6034f, 144.5187f);
                    break;

                case 64:
                    position = new(-733.4767f, 593.2111f, 141.5178f);
                    break;

                case 65:
                    position = new(-852.9005f, 694.7808f, 148.0741f);
                    break;

                case 66:
                    position = new(-1294.2745f, 454.0578f, 96.7013f);
                    break;

                case 67:
                    position = new(373.8f, 428.4f, 145.7f);
                    break;
            }
        }

        int func_5591(int iParam0)//Position - 0x1CDAF5
        {
            return iParam0 switch
            {
                1 or 2 or 3 or 4 or 5 or 6 or 7 => 1,
                8 or 9 or 10 or 11 or 12 or 13 or 14 or 15 or 16 or 69 or 68 or 66 or 67 => 8,
                17 or 18 or 19 or 20 or 21 or 22 or 23 or 70 or 71 or 72 => 17,
                61 or 62 or 63 or 64 or 65 => 61,
                73 or 74 or 75 or 76 => 73,
                77 or 78 or 79 or 80 or 81 or 82 => 77,
                83 or 84 or 85 => 83,
                86 => 86,
                87 or 88 or 89 or 90 => 88,
                91 or 92 or 93 or 94 or 95 or 96 => 91,
                97 or 98 or 99 or 100 or 101 or 102 => 97,
                103 or 106 or 109 or 112 or 104 or 107 or 110 or 113 or 105 or 108 or 111 or 114 => 109,
                _ => -1,
            };
        }
        int func_5594(int iParam0)//Position - 0x1CDD9C
        {
            return func_5591(iParam0) switch
            {
                83 => 8,
                88 => 9,
                91 or 97 => 9,
                109 => 4,
                _ => 0,
            };
        }

        bool func_6659(int iParam0, int iParam1)//Position - 0x2117CF
        {
            if (func_5591(iParam1) == 83)
            {
                switch (iParam0)
                {
                    case 0:
                        return Tunables.Global_262145.Value<int>("f_13303") == 1 /* Tunable: APT_DISABLE_INTERIOR1 */;

                    case 1:
                        return Tunables.Global_262145.Value<int>("f_13304") == 1 /* Tunable: APT_DISABLE_INTERIOR2 */;

                    case 2:
                        return Tunables.Global_262145.Value<int>("f_13305") == 1 /* Tunable: APT_DISABLE_INTERIOR3 */;

                    case 3:
                        return Tunables.Global_262145.Value<int>("f_13306") == 1 /* Tunable: APT_DISABLE_INTERIOR4 */;

                    case 4:
                        return Tunables.Global_262145.Value<int>("f_13307") == 1 /* Tunable: APT_DISABLE_INTERIOR5 */;

                    case 5:
                        return Tunables.Global_262145.Value<int>("f_13308") == 1 /* Tunable: APT_DISABLE_INTERIOR6 */;

                    case 6:
                        return Tunables.Global_262145.Value<int>("f_13309") == 1 /* Tunable: APT_DISABLE_INTERIOR7 */;

                    case 7:
                        return Tunables.Global_262145.Value<int>("f_13310") == 1 /* Tunable: APT_DISABLE_INTERIOR8 */;

                }
            }
            else if (func_5591(iParam1) == 88)
            {
                switch (iParam0)
                {
                    case 0:
                        return false;

                    case 1:
                        return false;

                    case 2:
                        return false;

                    case 3:
                        return false;

                    case 4:
                        return false;

                    case 5:
                        return false;

                    case 6:
                        return false;

                    case 7:
                        return false;

                    case 8:
                        return false;

                }
            }
            else if (func_5591(iParam1) == 91 || func_5591(iParam1) == 97)
            {
                switch (iParam0)
                {
                    case 0:
                        return false;

                    case 1:
                        return false;

                    case 2:
                        return false;

                    case 3:
                        return false;

                    case 4:
                        return false;

                    case 5:
                        return false;

                    case 6:
                        return false;

                    case 7:
                        return false;
                }
            }
            else if (func_5591(iParam1) == 109)
            {
                switch (iParam0)
                {
                    case 0:
                        return false;

                    case 1:
                        return false;

                    case 2:
                        return false;

                    case 3:
                        return false;
                }
            }
            return false;
        }
        bool func_7474(int iParam0, ref int iParam1)//Position - 0x27D003
        {
            int iVar0;

            if (func_5649(iParam0))
            {
                iParam1 = 0;
                iVar0 = 0;
                while (iVar0 < func_5594(iParam0))
                {
                    if (!func_6659(iVar0, iParam0))
                    {
                        iParam1 = iVar0;
                    }
                    else
                    {
                        iParam1 = 0;
                    }
                    iVar0++;
                }
                return true;
            }
            iParam1 = 0;
            return false;
        }
        bool func_5649(int iParam0)//Position - 0x1CFB76
        {
            return iParam0 switch
            {
                83 or 84 or 85 or 87 or 88 or 89 or 90 or 91 or 92 or 93 or 94 or 95 or 96 or 97 or 98 or 99 or 100 or 101 or 102 or 103 or 104 or 105 or 106 or 107 or 108 or 109 or 110 or 111 or 112 or 113 or 114 => true,
                _ => false,
            };
        }
    }
}

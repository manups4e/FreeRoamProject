using FreeRoamProject.Shared.Properties.Enums;

namespace FreeRoamProject.Shared.Core.ApartmentsShared
{
    public class Global_4280768 // freemode_init.c / fm_mission_controller_2020.c
    {
        public Vector3 f_0 { get; set; }
        public float f_3 { get; set; }
        public Vector3 f_4 { get; set; }
        public float f_7 { get; set; }
        public Vector3 f_8 = new();
        public float f_11 = 0;
        public Vector3 f_12 { get; set; }
    }

    // coordinates are in startup.c func_34 (a while iVarsomething < 131)
    public class PropertyData()
    {
        /// <summary>
        /// func_34 -> switch case uParam0_f_35, func_35 for all the coordinates
        /// </summary>
        public int ApartmentType { get; set; }
        public string Label => (int)Index switch
        {
            1 => "MP_PROP_1",/* GXT: Eclipse Towers, Apt 31 */
            2 => "MP_PROP_2",/* GXT: Eclipse Towers, Apt 9 */
            3 => "MP_PROP_3",/* GXT: Eclipse Towers, Apt 40 */
            4 => "MP_PROP_4",/* GXT: Eclipse Towers, Apt 5 */
            5 => "MP_PROP_5",/* GXT: 3 Alta St, Apt 10 */
            6 => "MP_PROP_6",/* GXT: 3 Alta St, Apt 57 */
            7 => "MP_PROP_7",/* GXT: Del Perro Heights, Apt 20 */
            8 => "MP_PROP_8",/* GXT: 1162 Power St, Apt 3 */
            9 => "MP_PROP_9",/* GXT: 0605 Spanish Ave, Apt 1 */
            10 => "MP_PROP_10",/* GXT: 0604 Las Lagunas Blvd, Apt 4 */
            11 => "MP_PROP_11",/* GXT: 0184 Milton Rd, Apt 13 */
            12 => "MP_PROP_12",/* GXT: The Royale, Apt 19 */
            13 => "MP_PROP_13",/* GXT: 0504 S Mo Milton Dr */
            14 => "MP_PROP_14",/* GXT: 0115 Bay City Ave, Apt 45 */
            15 => "MP_PROP_15",/* GXT: 0325 South Rockford Dr */
            16 => "MP_PROP_16",/* GXT: Dream Tower, Apt 15 */
            17 => "MP_PROP_17",/* GXT: 2143 Las Lagunas Blvd, Apt 9 */
            18 => "MP_PROP_18",/* GXT: 1561 San Vitas St, Apt 2 */
            19 => "MP_PROP_19",/* GXT: 0112 S Rockford Dr, Apt 13 */
            20 => "MP_PROP_20",/* GXT: 2057 Vespucci Blvd, Apt 1 */
            21 => "MP_PROP_21",/* GXT: 0069 Cougar Ave, Apt 19 */
            22 => "MP_PROP_22",/* GXT: 1237 Prosperity St, Apt 21 */
            23 => "MP_PROP_23",/* GXT: 1115 Blvd Del Perro, Apt 18 */
            24 => "MP_PROP_24",/* GXT: 0120 Murrieta Heights */
            25 => "MP_PROP_25",/* GXT: Unit 14 Popular St */
            26 => "MP_PROP_26",/* GXT: Unit 2 Popular St */
            27 => "MP_PROP_27",/* GXT: 331 Supply St */
            28 => "MP_PROP_28",/* GXT: Unit 1 Olympic Fwy */
            29 => "MP_PROP_29",/* GXT: 0754 Roy Lowenstein Blvd */
            30 => "MP_PROP_30",/* GXT: 12 Little Bighorn Ave */
            31 => "MP_PROP_31",/* GXT: Unit 124 Popular St */
            32 => "MP_PROP_32",/* GXT: 0552 Roy Lowenstein Blvd */
            33 => "MP_PROP_33",/* GXT: 0432 Davis Ave */
            34 => "MP_PROP_34",/* GXT: Del Perro Heights, Apt 7 */
            35 => "MP_PROP_35",/* GXT: Weazel Plaza, Apt 101 */
            36 => "MP_PROP_36",/* GXT: Weazel Plaza, Apt 70 */
            37 => "MP_PROP_37",/* GXT: Weazel Plaza, Apt 26 */
            38 => "MP_PROP_38",/* GXT: 4 Integrity Way, Apt 30 */
            39 => "MP_PROP_39",/* GXT: 4 Integrity Way, Apt 35 */
            40 => "MP_PROP_40",/* GXT: Richards Majestic, Apt 4 */
            41 => "MP_PROP_41",/* GXT: Richards Majestic, Apt 51 */
            42 => "MP_PROP_42",/* GXT: Tinsel Towers, Apt 45 */
            43 => "MP_PROP_43",/* GXT: Tinsel Towers, Apt 29 */
            44 => "MP_PROP_44",/* GXT: 142 Paleto Blvd */
            45 => "MP_PROP_45",/* GXT: 1 Strawberry Ave */
            46 => "MP_PROP_46",/* GXT: 1932 Grapeseed Ave */
            47 => "MP_PROP_48",/* GXT: 1920 Senora Way */
            48 => "MP_PROP_49",/* GXT: 2000 Great Ocean Highway */
            49 => "MP_PROP_50",/* GXT: 197 Route 68 */
            50 => "MP_PROP_51",/* GXT: 870 Route 68 Approach */
            51 => "MP_PROP_52",/* GXT: 1200 Route 68 */
            52 => "MP_PROP_57",/* GXT: 8754 Route 68 */
            53 => "MP_PROP_59",/* GXT: 1905 Davis Ave */
            54 => "MP_PROP_60",/* GXT: 1623 South Shambles St */
            55 => "MP_PROP_61",/* GXT: 4531 Dry Dock St */
            56 => "MP_PROP_62",/* GXT: 1337 Exceptionalists Way */
            57 => "MP_PROP_63",/* GXT: Unit 76 Greenwich Parkway */
            58 => "MP_PROP_64",/* GXT: Garage Innocence Blvd */
            59 => "MP_PROP_65",/* GXT: 634 Blvd Del Perro */
            60 => "MP_PROP_66",/* GXT: 0897 Mirror Park Blvd */
            61 => "MP_PROP_67",/* GXT: Eclipse Towers, Apt 3 */
            62 => "MP_PROP_68",/* GXT: Del Perro Heights, Apt 4 */
            63 => "MP_PROP_69",/* GXT: Richards Majestic, Apt 2 */
            64 => "MP_PROP_70",/* GXT: Tinsel Towers, Apt 42 */
            65 => "MP_PROP_71",/* GXT: 4 Integrity Way, Apt 28 */
            66 => "MP_PROP_72",/* GXT: 4 Hangman Ave */
            67 => "MP_PROP_73",/* GXT: 12 Sustancia Rd */
            68 => "MP_PROP_74",/* GXT: 4584 Procopio Dr */
            69 => "MP_PROP_75",/* GXT: 4401 Procopio Dr */
            70 => "MP_PROP_76",/* GXT: 0232 Paleto Blvd */
            71 => "MP_PROP_77",/* GXT: 140 Zancudo Ave */
            72 => "MP_PROP_78",/* GXT: 1893 Grapeseed Ave */
            83 => "MP_PROP_79",/* GXT: Eclipse Towers, Penthouse Suite 1 */
            84 => "MP_PROP_80",/* GXT: Eclipse Towers, Penthouse Suite 2 */
            85 => "MP_PROP_81",/* GXT: Eclipse Towers, Penthouse Suite 3 */
            73 => "MP_PROP_83",/* GXT: 3655 Wild Oats Drive */
            74 => "MP_PROP_84",/* GXT: 2044 North Conker Avenue */
            75 => "MP_PROP_85",/* GXT: 2868 Hillcrest Avenue */
            76 => "MP_PROP_86",/* GXT: 2862 Hillcrest Avenue */
            77 => "MP_PROP_87",/* GXT: 3677 Whispymound Drive */
            78 => "MP_PROP_89",/* GXT: 2117 Milton Road */
            79 => "MP_PROP_90",/* GXT: 2866 Hillcrest Avenue */
            80 => "MP_PROP_92",/* GXT: 2874 Hillcrest Avenue */
            81 => "MP_PROP_94",/* GXT: 2113 Mad Wayne Thunder Drive */
            82 => "MP_PROP_95",/* GXT: 2045 North Conker Avenue */
            (int)PropertiesEnum.PROPERTY_YACHT_APT_1_BASE => "PM_SPAWN_Y",
            (int)PropertiesEnum.PROPERTY_OFFICE_1 => "MP_PROP_OFF1",
            (int)PropertiesEnum.PROPERTY_OFFICE_2_BASE => "MP_PROP_OFF2",
            (int)PropertiesEnum.PROPERTY_OFFICE_3 => "MP_PROP_OFF3",
            (int)PropertiesEnum.PROPERTY_OFFICE_4 => "MP_PROP_OFF4",
            (int)PropertiesEnum.PROPERTY_CLUBHOUSE_1_BASE_A => "MP_PROP_CLUBH1",
            (int)PropertiesEnum.PROPERTY_CLUBHOUSE_2_BASE_A => "MP_PROP_CLUBH2",
            (int)PropertiesEnum.PROPERTY_CLUBHOUSE_3_BASE_A => "MP_PROP_CLUBH3",
            (int)PropertiesEnum.PROPERTY_CLUBHOUSE_4_BASE_A => "MP_PROP_CLUBH4",
            (int)PropertiesEnum.PROPERTY_CLUBHOUSE_5_BASE_A => "MP_PROP_CLUBH5",
            (int)PropertiesEnum.PROPERTY_CLUBHOUSE_6_BASE_A => "MP_PROP_CLUBH6",
            (int)PropertiesEnum.PROPERTY_CLUBHOUSE_7_BASE_B => "MP_PROP_CLUBH7",
            (int)PropertiesEnum.PROPERTY_CLUBHOUSE_8_BASE_B => "MP_PROP_CLUBH8",
            (int)PropertiesEnum.PROPERTY_CLUBHOUSE_9_BASE_B => "MP_PROP_CLUBH9",
            (int)PropertiesEnum.PROPERTY_CLUBHOUSE_10_BASE_B => "MP_PROP_CLUBH10",
            (int)PropertiesEnum.PROPERTY_CLUBHOUSE_11_BASE_B => "MP_PROP_CLUBH11",
            (int)PropertiesEnum.PROPERTY_CLUBHOUSE_12_BASE_B => "MP_PROP_CLUBH12",
            (int)PropertiesEnum.PROPERTY_OFFICE_1_GARAGE_LVL1 or
            (int)PropertiesEnum.PROPERTY_OFFICE_2_GARAGE_LVL1 or
            (int)PropertiesEnum.PROPERTY_OFFICE_3_GARAGE_LVL1 or
            (int)PropertiesEnum.PROPERTY_OFFICE_4_GARAGE_LVL1 => "MP_PROP_OFFG1",
            (int)PropertiesEnum.PROPERTY_OFFICE_1_GARAGE_LVL2 or
            (int)PropertiesEnum.PROPERTY_OFFICE_2_GARAGE_LVL2 or
            (int)PropertiesEnum.PROPERTY_OFFICE_3_GARAGE_LVL2 or
            (int)PropertiesEnum.PROPERTY_OFFICE_4_GARAGE_LVL2 => "MP_PROP_OFFG2",
            (int)PropertiesEnum.PROPERTY_OFFICE_1_GARAGE_LVL3 or
            (int)PropertiesEnum.PROPERTY_OFFICE_2_GARAGE_LVL3 or
            (int)PropertiesEnum.PROPERTY_OFFICE_3_GARAGE_LVL3 or
            (int)PropertiesEnum.PROPERTY_OFFICE_4_GARAGE_LVL3 => "MP_PROP_OFFG3",
            (int)PropertiesEnum.PROPERTY_IMPEXP_VEH_WAREHOUSE => "IE_WARE_1",
            (int)PropertiesEnum.PROPERTY_MULTISTOREY_GARAGE => "MSG_NME_1",
            _ => "",
        };
        public string Description => (int)Index switch
        {
            1 => "MP_PROP_1DES", /* GXT: This luxury triplex is move-in ready! The previous owner was so rich he just left all his furniture. Just bring yourself and be ready for lots of new superficial friends when people find out you live on Eclipse Boulevard in Rockford Hills. Includes 10-car garage. */
            2 => "MP_PROP_2DES", /* GXT: A massive, furnished, luxury triplex at this price? You've gotta love a bargain like this! Snap it up now before President Lawton loses the next election and they tax the hell out of you. Includes 10-car garage. */
            3 => "MP_PROP_3DES", /* GXT: Eclipse Towers on Eclipse Boulevard... this is the best address in Rockford Hills! Stand at your floor-to-ceiling windows, take in the spectacular panoramic views, pour yourself a drink and toast how amazing your life is while you look down on everybody else. Includes 10-car garage. */
            4 => "MP_PROP_4DES", /* GXT: Upper class living at middle class prices! Are you a single-digit millionaire who wants to live like a double-digit millionaire? You'll never find a better deal on a luxury condo in Rockford Hills than this again. Act now, it won't last! Includes 10-car garage. */
            5 => "MP_PROP_5DES", /* GXT: With its own Bean Machine outlet on the ground floor and a short commute to the financial center, this luxury condo on Alta Street in Downtown Los Santos is the perfect pad for the banker who never sleeps because he's having too much fun gambling with other people's money. Includes 10-car garage. */
            6 => "MP_PROP_6DES", /* GXT: Situated at the epicenter of the Los Santos financial, business and high-end shopping districts, you'll never have to see a poor person again at this luxury condo on Alta Street if you don't want to. Everything you need is right on your doorstep. Includes 10-car garage. */
            7 => "MP_PROP_7DES", /* GXT: This luxury condo on Marathon Avenue and Prosperity Street, in one of the most stylish apartment buildings in hip Del Perro, directly opposite the Bahama Mamas nightclub for the perfect release at the end of a hard day's work. Includes 10-car garage. */
            8 => "MP_PROP_8DES", /* GXT: Located steps away from a skate park, this cute-as-a-button one-bedroom in Hawick is perfect for families with teenage children or tragic 30-something hipsters with fixies. Includes 6-car garage. */
            9 => "MP_PROP_9DES", /* GXT: This newly-renovated one-bedroom in Downtown Vinewood is a STEAL!~n~Hurry this one won't last! It did last!~n~$10,000 price reduction!~n~Crazy value!~n~Move NOW the price is right!~n~Everything's negotiable. Motivated seller.~n~Reduced again for quick sale!~n~WILL SOMEONE JUST BUY THIS ALREADY??? Includes 6-car garage. */
            10 => "MP_PROP_10DES", /* GXT: This building has seen better days - the closest thing to a doorman is a homeless guy you sometimes have to step over to get into the lobby at night - but how else are you going to find a Vinewood apartment in your price range? Hope you like the smell of urine.~n~Includes 6-car garage. */
            11 => "MP_PROP_11DES", /* GXT: Cozy one-bedroom in a cute West Vinewood apartment block! You'll only share the building with a few other units, meaning fewer neighbors for you to grow to despise. Includes 6-car garage. */
            12 => "MP_PROP_12DES", /* GXT: The Royale apartment building in West Vinewood might not look regal on the outside but you'll live like a prince on the inside! PS Princes are douches.~n~Includes 6-car garage. */
            13 => "MP_PROP_13DES", /* GXT: This modern, renovated one-bedroom is in a well-maintained building in a great West Vinewood location. Buy now at the bottom of the market! Property values can't go any lower! We're absolutely sure this time! Includes 6-car garage. */
            14 => "MP_PROP_14DES", /* GXT: Hello, sailor! This renovated, fully-furnished apartment is right on the waterfront in Puerto Del Sol. Perfect for picking up other sailors.~n~Includes 6-car garage. */
            15 => "MP_PROP_15DES", /* GXT: Location is in the eye of the beholder! Some might call this a busy traffic junction, we call it a Commuter's Dream! Some might call this Little Seoul, we call it Vespucci so we can up the price!~n~Includes 6-car garage. */
            16 => "MP_PROP_16DES", /* GXT: Join the other creative types flocking to this neighborhood. With easy access to both a movie theater and a church, this apartment in Dream Tower is perfect for lovers of fiction.~n~Includes 6-car garage. */
            17 => "MP_PROP_17DES", /* GXT: What this Hawick apartment lacks in space and all-round condition, it makes up for in proximity to the local liquor store. Drown in debt and your sorrows.~n~Includes 2-car garage. */
            18 => "MP_PROP_18DES", /* GXT: Original features! This cozy apartment in West Vinewood had only one owner, who didn't update a single thing since he moved in there 40 years ago and then passed away – it was days before anyone noticed. Includes 2-car garage. */
            19 => "MP_PROP_19DES", /* GXT: This compact apartment in a 2-story apartment building has been meticulously maintained in its original condition! Semi-partial ocean view! Includes 2-car garage. */
            20 => "MP_PROP_20DES", /* GXT: The apartment building has seen better days but this affordable unit still has a Little Soul and a Lot of Potential! Bring your imagination! And an exterminator.~n~Includes 2-car garage. */
            21 => "MP_PROP_21DES", /* GXT: This fixer-upper offers stunning views of the cemetery to at once remind you of your mortality and motivate you to get your act together and buy a better apartment one day.~n~Includes 2-car garage. */
            22 => "MP_PROP_22DES", /* GXT: With both Wigwam and Up-n-Atom right on your doorstep, burger enthusiasts will be spoiled for choice at this apartment located in Del Perro or Morningwood, depending on which side of the building you stand. Includes 2-car garage. */
            23 => "MP_PROP_23DES", /* GXT: With a funky retro décor and carpeted throughout, you can literally smell the history in this Del Perro apartment that features an almost unobstructed ocean view for an almost unbeatable price. Includes 2-car garage. */
            24 => "MP_PROP_24DES", /* GXT: 10-Car Garage - With good access to the major roadways in and out of Los Santos, this spacious garage is perfect for the man or woman who might need to leave town in a hurry. Or is obsessed with cars. */
            25 => "MP_PROP_25DES", /* GXT: 6-Car Garage - If you're an individual who likes to keep their business private, look no further than this secluded garage in East Los Santos. */
            26 => "MP_PROP_26DES", /* GXT: 10-Car Garage - Spacious garage in prime East Los Santos. Panoramic views of urban blight, walking distance to gang members. */
            27 => "MP_PROP_27DES", /* GXT: 10-Car Garage - Newly renovated garage with excellent square footage and direct road access. What better place to keep brand-new vehicles than the neighborhood with the highest crime rate in Los Santos? */
            28 => "MP_PROP_28DES", /* GXT: 6-Car Garage - A good-sized garage in a quiet location within walking distance of the train for those days when you feel extra guilty about your 6-car carbon footprint. */
            29 => "MP_PROP_29DES", /* GXT: 2-Car Garage - Located just a few brain-melting steps away from an electrical substation, you'll never have to worry losing power or reaching old age again at this garage in East Los Santos. */
            30 => "MP_PROP_30DES", /* GXT: 2-Car Garage - Affluent on the inside, effluent on the outside! This garage offers panoramic views of the Los Santos waterways. */
            31 => "MP_PROP_31DES", /* GXT: 2-Car Garage - Calling all bargain hunters! In today's economy, it's all about desirable properties in undesirable areas. East Los Santos? We prefer to call it 'South of Vinewood'! Plus if the economy keeps tanking, you can go live in it! */
            32 => "MP_PROP_32DES", /* GXT: 6-Car Garage - This garage is in a killer area... literally! Be first to gentrify this neighborhood! In 20 years, it will be the next big thing! */
            33 => "MP_PROP_33DES", /* GXT: 6-Car Garage - High standards in real estate, low standards in women? End the day with your own oil change at this garage located across from a strip club! */
            34 => "MP_PROP_34DES", /* GXT: Luxury Del Perro Heights apartment complex! For all you voyeurs out there! This spectacular condo is one of the lower units so might not boast the best views, but all the buildings around you will have a direct eyeline into your awesome life 24/7. Includes 10-car garage. */
            35 => "MP_PROP_35DES", /* GXT: Calling all actors! This is your chance to live on sought-after Movie Star Way in prime Rockford Hills directly opposite the legendary Richard Majestic film studios. Stagger out of your front door right onto set! Includes 10-car garage. */
            36 => "MP_PROP_36DES", /* GXT: Movie Star Way! Don't miss this opportunity to live in one of the most exclusive apartment complexes in Rockford Hills. Even the janitor earns six figures in this building.~n~Includes 10-car garage. */
            37 => "MP_PROP_37DES", /* GXT: This spectacular condo on Movie Star Way in prime Rockford Hills is move-in ready! Don't worry if you're a rich Los Santos philistine with no taste - it's all been picked out for you. All furniture, appliances, fixtures and art included.~n~Includes 10-car garage. */
            38 => "MP_PROP_38DES", /* GXT: No dropped calls here! This luxury condo is located in the same building as Tinkle Mobile's headquarters in the new real estate hotspot of Downtown Los Santos. This is such an up-and-coming neighborhood, you can literally see the construction from your window!~n~Includes 10-car garage. */
            39 => "MP_PROP_39DES", /* GXT: This beautiful Downtown triplex apartment has spectacular views of Los Santos and the iconic Vinewood Sign in the distance. Watch all the people chasing the dream while you live it! Includes 10-car garage. */
            40 => "MP_PROP_40DES", /* GXT: This breathtaking luxury condo on Movie Star Way in Rockford Hills is a stone's throw from Richards Majestic Movie Studios, AKAN Records and a Sperm Donor Clinic. The ultimate trifecta of dying industries! Includes 10-car garage. */
            41 => "MP_PROP_41DES", /* GXT: A luxury condo on Movie Star Way in Rockford Hills? This is one of the trendiest addresses in Los Santos! Imagine if all your neighbors were hedge fund managers and celebrities? Come on, live the dream. Includes 10-car garage. */
            42 => "MP_PROP_42DES", /* GXT: Your split personality will be right at home in this retro-slash-ultramodern apartment building on Boulevard Del Perro. Go mad in style. Includes 10-car garage. */
            43 => "MP_PROP_43DES", /* GXT: Parquet flooring, granite counter tops, floating fireplace, bland modern art, walk-in closet, towel warmers, leather headboard, man cave...this luxury condo in Tinsel Towers on Boulevard Del Perro checks all the boxes on the new-money millionaire tick list.~n~Includes 10-car garage. */
            44 => "MP_PROP_44DES", /* GXT: 2-Car Garage - Annexed to a gas station and within easy distance of a number of cheap motels, this garage on Paleto Blvd in Paleto Bay has all you need for the perfect escape from the city. */
            45 => "MP_PROP_45DES", /* GXT: 2-Car Garage - This garage near Paleto Blvd in Paleto Bay has seen better days but there's a barber's, a tattoo parlor and a Cluckin' Bell factory on your doorstep...so what more do you need? */
            46 => "MP_PROP_46DES", /* GXT: 2-Car Garage - The town of Grapeseed offer a unique blend of heavy industry and genetically-modified farming that explains why everyone born there in the last 20 years looks so funny. This small garage on Grapeseed Avenue needs some TLC but is priced to sell. */
            47 => "MP_PROP_48DES", /* GXT: 2-Car Garage - This garage is situated on the site of Ron Alternates on N. Senora Way. What better way to feel better about your carbon footprint than by storing your gas-guzzlers inside a wind farm? */
            48 => "MP_PROP_49DES", /* GXT: 2-Car Garage - Across from the beach, ocean views, steps from a delicious seafood restaurant, this property on Great Ocean Highway in North Chumash is in an unbeatable location! The catch? It's a garage... */
            49 => "MP_PROP_50DES", /* GXT: 2-Car Garage - Small one-door garage for sale on Route 68 on Harmony. With a rundown general store, a local arm-wrestling haunt and a seedy motel all nearby, park up and live the dream! */
            50 => "MP_PROP_51DES", /* GXT: 6-Car Garage - Garage in need of some TLC for sale on Senora Rd in the Grand Senora Desert. Nothing of great note in the surrounding area. It's a garage. In a desert. */
            51 => "MP_PROP_52DES", /* GXT: 2-Car Garage - Steps from a liquor store, a Dollar Pills pharmacy, a Suburban store, and an Animal Ark pet store, this garage on Route 68 in Harmony is a hipster's dream. Booze, cigarettes, faux-vintage clothing and organic dog food in one! */
            52 => "MP_PROP_57DES", /* GXT: 6-Car Garage - Located behind an Ammu-Nation store and near to the Fort Zancudo Military Base, you won't have to worry about security at this garage on Route 68. */
            53 => "MP_PROP_59DES", /* GXT: 6-Car Garage - Calling all Los Santos Panic fans! This garage on Crusade Road is in a prime location just down the road from the Maze Bank Arena! */
            54 => "MP_PROP_60DES", /* GXT: 10-Car Garage - Are you in need of a low-profile lock-up where people won't ask too many questions? Look no further than this garage on South Shambles in Cypress Flats. */
            55 => "MP_PROP_61DES", /* GXT: 6-Car Garage - If you're looking for a desolate, industrial lock-up far away from prying eyes, this garage on Dry Dock St in Cypress Flats is the one for you! */
            56 => "MP_PROP_62DES", /* GXT: 10-Car Garage - Garage for sale on Exceptionalists Way. Why would you need a spacious, anonymous, non-descript lock-up with lots of space for storage close to the airport? We won't ask if you don't tell. */
            57 => "MP_PROP_63DES", /* GXT: 10-Car Garage - In a prime location near Greenwich parkway in Los Santos International Airport, next door to Bilgeco Shipping services, this garage is perfect for a man or woman who might need to transport something in a hurry or get out of a town in a hurry. */
            58 => "MP_PROP_64DES", /* GXT: 2-Car Garage - Garage for sale on Innocence Blvd in La Puerta. How can there be this many garages for sale in Los Santos? We're as puzzled by this real estate boom as you are. */
            59 => "MP_PROP_65DES", /* GXT: 2-Car Garage - If you're feeling the pinch of the economic downturn but desperate for a prime Rockford Hills address, this garage on Boulevard Del Perro might be the perfect compromise! */
            60 => "MP_PROP_66DES", /* GXT: 2-Car Garage - Garage for sale on Mirror Park Blvd in East Vinewood. If you're looking for a garage in Los Santos, don't delay! It's an incredible buyer's market right now. They're everywhere! */
            61 => "MP_PROP_67DES", /* GXT: Part of The High Life Update. Perfectly proportioned, beautifully presented lateral living opportunity on exquisite Eclipse Blvd. This apartment is as unique as the new cheekbones your surgeon just gave you... by that we mean you'll see them all over town. Includes 10-car garage. */
            62 => "MP_PROP_68DES", /* GXT: Part of The High Life Update. Enjoy ocean views far above the fray of tourists and bums on Del Perro Beach with this lateral living opportunity for the super rich. If we can overpay for something, we have, and we're passing the expense on down to you. Includes 10-car garage. */
            63 => "MP_PROP_69DES", /* GXT: Part of The High Life Update. Own a piece of glamorous old Vinewood, albeit a very small and expensive piece that's been made to look just like the other super-rich corners of Los Santos. A contemporary lateral living experience with one foot in the past. Includes 10-car garage. */
            64 => "MP_PROP_70DES", /* GXT: Part of The High Life Update. A picture-perfect lateral living experience in one of Los Santos' most sought-after tower blocks. These gorgeous lateral apartments only become available when hedgefunder residents have massive drug-induced heart attacks or get arrested for killing hookers. Includes 10-car garage. */
            65 => "MP_PROP_71DES", /* GXT: Part of The High Life Update. Live in the clouds while your bank balance hits the floor. An apartment so conspicuously expensive all your friends will immediately know how much you paid for it. The Downtown lateral living experience for people who secretly want to be LC based. Includes 10-car garage. */
            66 => "MP_PROP_72DES", /* GXT: Part of The Independence Day Special. Crazy movie director across the road? Check. Astronomically over-priced property where your car has more square footage than you do? Check. If you're looking for the full Vinewood Hills experience, this modest home ticks all the boxes. Includes 6-car garage. */
            67 => "MP_PROP_73DES", /* GXT: Part of The Independence Day Special. Calling all gentrifiers... El Burro Heights is ripe for hostile takeover! Pack up the espresso machine, labradoodle and deliberately tousled toddler and snap up this property before it's too late! Act now, or you'll be priced out of this neighborhood within a year! Includes 6-car garage. */
            68 => "MP_PROP_74DES", /* GXT: Part of The Independence Day Special. Check out the water feature in the front yard! This is coastal, provincial living at its very finest. Worried about shade? Want easy access to groceries? How about two for the price of one? This house backs right onto the supermarket, blocking out all natural light. Includes 6-car garage. */
            69 => "MP_PROP_75DES", /* GXT: Part of The Independence Day Special. Stunning views of rapidly rising sea levels! And talk about amenities! This Paleto Bay beauty is walking distance to a dive bar, hospital, funeral home, crematorium and gun store, so you can go out on the town secure in the knowledge that you're covered for every eventuality. Includes 6-car garage. */
            70 => "MP_PROP_76DES", /* GXT: Part of The Independence Day Special. Fall asleep to the sounds of the ocean and bums dumpster-diving in the parking lot. This cute-as-a-button property is centrally located on Paleto Bay's main street, a short walk from the coast and next door to the local supermarket. Includes 2-car garage. */
            71 => "MP_PROP_77DES", /* GXT: Part of The Independence Day Special. Beggars CAN be choosers! Waterfront living at a bargain price! Steps away from both a Chinese restaurant and a tattoo parlor, this Sandy Shores location offers no shortage of late-night decisions you'll regret in the morning. Includes 2-car garage. */
            72 => "MP_PROP_78DES", /* GXT: Part of The Independence Day Special. Location, location, location! Across from a feed store, minimart and discount clothes emporium, this house is right in the heart of the action on Grapeseed's main drag. Living on the cutting edge of rural retail! Includes 2-car garage. */
            83 => "MP_PROP_79DES", /* GXT: Is the 1% starting to feel a little crowded? Are you tired of single-digit millionaires cluttering up your elevator and groping your bellboy? Do you need a new way of expressing your bottomless contempt for your fellow man? Look no further: this lavish penthouse suite at the best address in town is expensive enough to keep the riff raff at bay until at least the next federal bailout. Access to our same-day redecorating service included as standard. Part of Executives and Other Criminals. */
            84 => "MP_PROP_80DES", /* GXT: Penthouse living isn't just about mindless luxury. It's about knowing that when you flush a dump you're literally crapping through every single one of the $500K hovels beneath you - and that's something that only money can buy. Access to our same-day redecorating service included as standard. Part of Executives and Other Criminals. */
            85 => "MP_PROP_81DES", /* GXT: Let's face it: we had you at the price tag. The fact that this happens to be one of the most decadent living spaces for hundreds of miles doesn't really matter. Just like its new owner, something this expensive doesn't need to be 'nice' or 'useful'. You're a perfect match. What are you waiting for? Access to our same-day redecorating service included as standard. Part of Executives and Other Criminals. */
            73 => "MP_PROP_83DES", /* GXT: Welcome to the heights of the Vinewood hills, where the average first time buyer is 24 and the web 2.0 entrepreneurs are only outnumbered by the swarms of fading teenage pop sensations. Buy in now while the price is still ridiculously high - what are you, sensible? Part of Executives and Other Criminals. */
            74 => "MP_PROP_84DES", /* GXT: San Andreas is a place where property values can only go up and high magnitude earthquakes never happen, so where better to balance a luxury apartment on stilts over a steep hillside in a crowded residential area? The first time you feel yourself and everything you own sway in a light breeze you'll be surprised how good this sounded on paper. Part of Executives and Other Criminals. */
            75 => "MP_PROP_85DES", /* GXT: The previous owner of this gorgeous cliffside manor died doing a yoga pose on the rear balcony railing... but at least they got the Snapmatic shot. It's a tough act to follow, but if you're rich and stupid enough to buy into this neighborhood you're already most of the way there. Just follow your fragile heart. Part of Executives and Other Criminals. */
            76 => "MP_PROP_86DES", /* GXT: Clinging to the side of the Vinewood hills like a dying oil tycoon clutching his carer-turned-sixth-wife, this three story mansion more than compensates for deep structural flaws with sumptuous interior design. Open plan kitchen, minimalist furnishings, ever-present vertigo: this one really has it all. Part of Executives and Other Criminals. */
            77 => "MP_PROP_87DES", /* GXT: The saps driving through downtown Vinewood on their morning commute need something to aspire to. They don't want to look up and see green, peaceful hills. They want to gaze through your floor-length windows and see you in nothing but a snakeskin posing pouch injecting cold press kale juice with your tantric yoga instructor. That's the kind of status that doesn't come cheap, so dig deep. Part of Executives and Other Criminals. */
            78 => "MP_PROP_89DES", /* GXT: Act now to secure your place at one of the quietest and most exclusive addresses in the city. All the other houses on this street were bought in the nineties by legitimate foreign investors who needed somewhere to store vast sums of legally acquired capital, and they've been empty ever since. It'll feel like you're living in an investment portfolio, but isn't that the point? Part of Executives and Other Criminals. */
            79 => "MP_PROP_90DES", /* GXT: Skyscraper views and lateral living are last year's kind of vanity project. Put a more contemporary spin on your raging superiority complex by forcing your butler to wheeze up and down all three stories of this hillside palace, while you take selfies with the spectacular views of thousands of more comfortable, less expensive places to live behind you. Part of Executives and Other Criminals. */
            80 => "MP_PROP_92DES", /* GXT: The tinnitus and smoker's cough are telling you that you've seen too much inner-city living, and we're telling you that this fantastically expensive apartment in leafy Vinewood is the answer to decades of hardened self-abuse. From here, you can gaze out across the whole town every morning as you retch into your green juice and paleo breakfast burrito. Just keep reminding yourself you're glad to get away from it all. Part of Executives and Other Criminals. */
            81 => "MP_PROP_94DES", /* GXT: Built in the 60s and surprising everyone by still being in once piece, this understated property may not look like much on the outside, but don't worry: inside it's identical to every other brainless yuppie's fantasy of open plan, designer living. Part of Executives and Other Criminals. */
            82 => "MP_PROP_95DES", /* GXT: Designed and constructed in direct violation of every building law in the state, this luxury apartment is a testament to the power of a can-do attitude and utter disregard for standards of health, safety and common sense. Time to pour yourself a drink, forget about the forty foot drop, and congratulate yourself on keeping that pioneer spirit alive. Part of Executives and Other Criminals. */
            (int)PropertiesEnum.PROPERTY_OFFICE_1 => "MP_PROP_96DES",
            (int)PropertiesEnum.PROPERTY_OFFICE_2_BASE => "MP_PROP_97DES",
            (int)PropertiesEnum.PROPERTY_OFFICE_3 => "MP_PROP_98DES",
            (int)PropertiesEnum.PROPERTY_OFFICE_4 => "MP_PROP_99DES",
            (int)PropertiesEnum.PROPERTY_CLUBHOUSE_1_BASE_A => "MP_CLUBH1DES",
            (int)PropertiesEnum.PROPERTY_CLUBHOUSE_2_BASE_A => "MP_CLUBH2DES",
            (int)PropertiesEnum.PROPERTY_CLUBHOUSE_3_BASE_A => "MP_CLUBH3DES",
            (int)PropertiesEnum.PROPERTY_CLUBHOUSE_4_BASE_A => "MP_CLUBH4DES",
            (int)PropertiesEnum.PROPERTY_CLUBHOUSE_5_BASE_A => "MP_CLUBH5DES",
            (int)PropertiesEnum.PROPERTY_CLUBHOUSE_6_BASE_A => "MP_CLUBH6DES",
            (int)PropertiesEnum.PROPERTY_CLUBHOUSE_7_BASE_B => "MP_CLUBH7DES",
            (int)PropertiesEnum.PROPERTY_CLUBHOUSE_8_BASE_B => "MP_CLUBH8DES",
            (int)PropertiesEnum.PROPERTY_CLUBHOUSE_9_BASE_B => "MP_CLUBH9DES",
            (int)PropertiesEnum.PROPERTY_CLUBHOUSE_10_BASE_B => "MP_CLUBH10DES",
            (int)PropertiesEnum.PROPERTY_CLUBHOUSE_11_BASE_B => "MP_CLUBH11DES",
            (int)PropertiesEnum.PROPERTY_CLUBHOUSE_12_BASE_B => "MP_CLUBH12DES",
            (int)PropertiesEnum.PROPERTY_MULTISTOREY_GARAGE => "MP_MSG_DES",
            _ => ""
        };
        public Vector3 PurchaseLocation { get; set; } //vPurchaseLocation
        public Vector3[] BlipLocation = new Vector3[3]; //MAX_ENTRANCES
        public Vector3 HouseHeistExitLocation { get; set; }// vHouseHeistExitLocation
        public PropertyCamera CamData = new();
        public PropertiesEnum Index { get; set; }
        public int Value { get; set; }
        public int GarageSize { get; set; }
        public int Type { get; set; }
        public BuildingsEnum BuildingID { get; set; }
        public int NumEntrances { get; set; }
        public int ExtraEntrances { get; set; }
        public EntranceData[] Entrance = [new EntranceData(), new EntranceData(), new EntranceData()];
        public int NumberOfWindows { get; set; }
        public SomeWeirdCoordMetadata[] window = [new SomeWeirdCoordMetadata(), new SomeWeirdCoordMetadata()];
        public InteriorData House = new();
        public GarageData Garage = new();
        public BuildingRelated Building = new(); //building_properties
        public CCTV[] cctv = [new CCTV(), new CCTV(), new CCTV()];
        readonly bool bIsTruck = false;
    }

    public class BuildingRelated
    {
        public PropertiesEnum[] PropertiesInBuilding = [0, 0, 0, 0, 0, 0, 0, 0]; //MAX_PROPERTIES_IN_BUILDING
        public int NumProperties { get; set; }
    }

    public class PropertyCamera
    {
        public Vector3 Pos { get; set; }
        public Vector3 Rot { get; set; }
        public float FOV { get; set; }
    }

    public class SomeWeirdCoordMetadata
    {
        public Vector3 AreaAVec { get; set; }
        public Vector3 AreaBVec { get; set; }
        public float AreaWidth { get; set; }
        public Vector3 SpawnPoint { get; set; }
        public float PedRadius { get; set; }
        public float VehRadius { get; set; }
    }

    public class EntranceData
    {
        public MPPropertyNonAxis locateDetails = new();
        public Vector3 InPlayerLoc { get; set; }
        public float InPlayerHeading { get; set; }
        public Vector3 BuzzerLoc { get; set; }
        public float BuzzerHeading { get; set; }
        public Vector3 BuzzerProp { get; set; }
        public Vector3 BuzzerPropRot { get; set; }
        public int BuzzerType { get; set; }
        //MODEL_NAMES mnBuzzerProp
        public Vector3 EntranceMarkerLoc { get; set; }
        public EntranceType Type { get; set; }
    }

    public class MPPropertyNonAxis
    {
        public Vector3 Pos1 { get; set; }
        public Vector3 Pos2 { get; set; }
        public float Width { get; set; }
        public float EnterHeading { get; set; }
    }

    public class GarageData
    {
        public MPPropertyNonAxis AutoExitLoc = new();
        public MPPropertyNonAxis AutoExitToApart = new();
        public Vector3 FromHousePlayerLoc { get; set; }
        public float FromHousePlayerHeading { get; set; }
        public Vector3 InPlayerLoc { get; set; }
        public float InPlayerHeading { get; set; }
        public Vector3 ExitPlayerPos { get; set; }
        public float ExitPlayerHeading { get; set; }
        public Vector3[] CarLoc = [new Vector3(), new Vector3(), new Vector3(), new Vector3(), new Vector3(), new Vector3(), new Vector3(), new Vector3(), new Vector3(), new Vector3(), new Vector3()];
        public float[] CarHeading = new float[11];
        public Vector3[] CarSpawnSafeLoc = [new Vector3(), new Vector3(), new Vector3(), new Vector3(), new Vector3(), new Vector3(), new Vector3(), new Vector3(), new Vector3(), new Vector3(), new Vector3()];
        public Vector3[] CarExitLoc = [new Vector3(), new Vector3(), new Vector3(), new Vector3(), new Vector3()];
        public float[] CarExitHeading = new float[5];
        public float[] CarExitWeight = new float[5];
        public Vector3 BuzzerLoc { get; set; }
        public CCTV cctv = new();
        public int Type { get; set; }
        public int NumBikeSlots { get; set; }
        public Vector3 MidPoint { get; set; }
        public MPPropertyNonAxis Bounds = new();
        public Vector3 DoorBlockerLoc { get; set; }
        public Vector3 DoorBlockerRot { get; set; }
        public Vector3 SafeCoronaLoc { get; set; }
    }

    public class CCTV
    {
        public Vector3 Pos { get; set; } //vPos & vRot are relative when the CCTV channel is specifed to... 
        public Vector3 Rot { get; set; } //...be attached to a vehicle (See UPDATE_VEHICLE_TO_ATTACH_TO in net_MP_CCTV.sch)
        public float FOV { get; set; }
        public float MaxAngleLeft { get; set; }//abs relative max left angle
        public float MaxAngleRight { get; set; }//abs relative max right angle 
    }

    public class InteriorData
    {
        public PropertyExit[] Exits = [new PropertyExit(), new PropertyExit(), new PropertyExit()]; //MAX_EXITS
        public Vector3 HeistPlanningLocate { get; set; }
        public Vector3 HeistCameraPos { get; set; }
        public Vector3 HeistCameraRot { get; set; }
        public float HeistFOV { get; set; }
        public Vector3 MidPoint { get; set; }
        public Vector3 BuzzerLoc { get; set; }
        public Vector3 WardrobeLoc = new();
        public float WardrobeHeading = 0;
        public MPPropertyNonAxis[] Bounds = [new MPPropertyNonAxis(), new MPPropertyNonAxis(), new MPPropertyNonAxis()];
        public ActivityPos[] activity = [new ActivityPos(), new ActivityPos(), new ActivityPos(), new ActivityPos(), new ActivityPos(), new ActivityPos(), new ActivityPos(), new ActivityPos(), new ActivityPos(), new ActivityPos(), new ActivityPos(), new ActivityPos(), new ActivityPos(), new ActivityPos()]; //MAX_ACTIVITIES
        public Vector3 HeistRadioLoc { get; set; }
        public Vector3 HeistRadioRot { get; set; }
        public BuzzerRelated BuzzerEnter = new();
        public ApartExit ExitScene = new();
        public Vector3 DoorBlockerLoc { get; set; }
        public Vector3 DoorBlockerRot { get; set; }
        public Vector3 SafeCoronaLoc { get; set; }
        // AMEC Heists // TODO: Check this is OK with Conor.
        public HeistRoom heistPlanning = new();
        public Vector3 CircleBoundPosition { get; set; }
        public float CircleBoundRadius { get; set; }
    }

    public class HeistRoom
    {
        public Vector3 BoardPosition { get; set; }
        public Vector3 BoardRotation { get; set; }
        public Vector3 MapPosition { get; set; }
        public Vector3 MapRotation { get; set; }
        public Vector3 CamPos_Overview { get; set; }
        public Vector3 CamPos_Map { get; set; }
        public Vector3 CamPos_Board { get; set; }
        public Vector3 CamPos_Desc { get; set; }
        public Vector3 CamPos_Stat { get; set; }
        public Vector3 CamRotGeneric { get; set; }
    }

    public class ApartExit
    {
        public Vector3 PlayerPos { get; set; }
        public float PlayerHeading { get; set; }
        public Vector3 SyncedSceneLoc { get; set; }
        public Vector3 SyncedSceneRot { get; set; }
    }

    public class BuzzerRelated
    {
        public Vector3 InsidePlayerPos { get; set; }
        public float InsidePlayerHeading { get; set; }
        public Vector3 OutsidePlayerPos { get; set; }
        public float OutsidePlayerHeading { get; set; }
        public Vector3 SyncedSceneLoc { get; set; }
        public Vector3 SyncedSceneRot { get; set; }
        public Vector3 InsidePlayerENDPos { get; set; }
        public float InsidePlayerENDHeading { get; set; }
        public Vector3 OutsidePlayerENDPos { get; set; }
        public float OutsidePlayerENDHeading { get; set; }
        public Vector3 OutsideStripperPos { get; set; }
        public float OutsideStripperHeading { get; set; }
    }

    public class ActivityPos
    {
        public Vector3 TriggerVec { get; set; }
        public float TriggerRot { get; set; }
        public Vector3 TriggerSizeVec { get; set; }
        public Vector3 SceneVec { get; set; }
        public Vector3 SceneRot { get; set; }
        public Vector3 LookAtVec { get; set; }
        public Vector3 AreaAVec { get; set; }
        public Vector3 AreaBVec { get; set; }
        public Vector3 CamVec { get; set; }
        public Vector3 CamRot { get; set; }
        public float CamView { get; set; }
        public Vector3 Cam2Vec { get; set; }
        public Vector3 Cam2Rot { get; set; }
        public Vector3 LookCamVec { get; set; }
        public Vector3 LookCamRot { get; set; }
        public Vector3 AboveCamVec { get; set; }
        public Vector3 AboveCamRot { get; set; }
        public Vector3 TurnOffCamVec { get; set; }
        public Vector3 TurnOffCamRot { get; set; }
        public Vector3 ExitFrameCamVec { get; set; }
        public Vector3 ExitFrameCamRot { get; set; }
        public Vector3 ExitCamVec { get; set; }
        public Vector3 ExitCamRot { get; set; }
        public Vector3 ShowerHeadVec { get; set; }
        public Vector3 ShowerHeadRot { get; set; }
        public Vector3 SteamVec { get; set; }
        public Vector3 SteamRot { get; set; }
        public Vector3 ExitShowerPos { get; set; }
        public float ExitShowerHeading { get; set; }
        public Vector3 GlassLoc { get; set; }
        //	VECTOR	vLapDancePlayerVec
        //	FLOAT	fLapDancePlayerRot
        //	
        //	VECTOR	vLapDanceStripperVec
        //	FLOAT	fLapDanceStripperRot
        //	
        //	VECTOR	vStripperExitVec
        public bool BedBong { get; set; }
        public bool FranklinBong { get; set; }
        public float BathAreaWidth { get; set; }
        public Vector3 DoorVec { get; set; }
        public Vector3 DoorRot { get; set; }
        public Vector3 BathroomDoorArea { get; set; }
        public Vector3 BathroomDoorAreaB { get; set; }
        public Vector3 ObjectLoc { get; set; }
    }

    public class PropertyExit
    {
        public MPPropertyNonAxis autoExitLoc = new();
        public Vector3 OutPlayerLoc { get; set; }
        public float OutPlayerHeading { get; set; }
    }
}
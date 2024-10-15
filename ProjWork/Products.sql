use GrocApp10424
 
 
select * from Products

select * from ProductTypes

select * from ProductBrands
 
INSERT INTO Products (name, description, price, pictureUrl, mfgDate, expDate, productTypeId, productBrandId) VALUES

('Fortune Basmati Rice', 'Premium quality basmati rice.', 

1200.00, 'https://localhost:7275/Public/Public/Images/BasmatiRice.png','2024-01-01', '2025-01-01', 1, 1)
 
INSERT INTO Products (name, description, price, pictureUrl, mfgDate, expDate, productTypeId, productBrandId) VALUES

('MDH Chana Masala', 'Spicy and flavorful chana masala.', 50.00, 'https://localhost:7275/Public/Images/mdhChana.png', '2024-01-01', '2025-01-01', 3, 2),

('Tata Salt', 'Iodized salt for daily use.', 20.00, 'https://localhost:7275/Public/Images/TataSalt.png', '2024-02-01', '2025-02-01', 3, 3),

('Aashirvaad Atta', 'Whole wheat flour for soft chapatis.', 300.00, 'https://localhost:7275/Public/Images/aashAtta.png', '2024-03-01', '2025-03-01', 4, 4),

('Parle G Biscuits', 'Classic glucose biscuits.', 40.00, 'https://localhost:7275/Public/Images/ParleG.png', '2024-04-01', '2025-04-01', 6, 5),

('Amul Butter', 'Creamy and delicious butter.', 50.00, 'https://localhost:7275/Public/Images/amulButter.png', '2024-05-01', '2025-05-01', 7, 6),

('Haldiram''s Bhujia', 'Crispy and spicy bhujia.', 100.00, 'https://localhost:7275/Public/Images/Haldirams.png', '2024-06-01', '2025-06-01', 6, 7),

('Dabur Honey', 'Pure and natural honey.', 200.00, 'https://localhost:7275/Public/Images/daburHoney.png', '2024-07-01', '2025-07-01', 8, 8),

('Patanjali Ghee', 'Pure cow ghee.', 500.00, 'https://localhost:7275/Public/Images/PatanjaliGhee.png', '2024-08-01', '2025-08-01', 5, 9),

('Britannia Cheese', 'Delicious and creamy cheese slices.', 150.00, 'https://localhost:7275/Public/Images/BritanniaCheese.png', '2024-09-01', '2025-09-01', 7, 10)

--new add

INSERT INTO Products (name, description, price, pictureUrl, mfgDate, expDate, productTypeId, productBrandId) VALUES
 ('Tata Sona Masoori Rice', 'High-quality masoori rice.', 1000.00, 'https://localhost:7275/Public/Images/SonaMasoori.jpg', '2024-01-01', '2025-01-01', 1, 3),

 ('Fortune Toor Dal', 'Premium quality toor dal.', 150.00, 'https://localhost:7275/Public/Images/ToorDal.jpg', '2024-01-01', '2025-01-01', 2, 1),
 ('Tata Urad Dal', 'High-quality urad dal.', 140.00, 'https://localhost:7275/Public/Images/UradDal.jpg', '2024-01-01', '2025-01-01', 2, 3),
 ('MDH Garam Masala', 'Authentic garam masala.', 70.00, 'https://localhost:7275/Public/Images/mdhGaram.jpg', '2024-01-01', '2025-01-01', 3, 2),
 ('Lays Classic Chips', 'Crispy and delicious potato chips.', 30.00, 'https://localhost:7275/Public/Images/LaysChips.jpg', '2024-07-01', '2025-07-01', 6, 4),
 ('Fortune Sunflower Oil', 'Refined sunflower oil.', 180.00, 'https://localhost:7275/Public/Images/SunflowerOil.jpg', '2024-05-01', '2025-05-01', 5, 1),
('Patanjali Mustard Oil', 'Pure mustard oil.', 150.00, 'https://localhost:7275/Public/Images/MustardOil.jpg', '2024-06-01', '2025-06-01', 5, 9),
('Nestle Everyday Milk', 'Instant milk powder.', 250.00, 'https://localhost:7275/Public/Images/NestleMilk.jpg', '2024-08-01', '2025-08-01', 8, 9),
('Himalaya Ashwagandha', 'Boosts energy and immunity.', 150.00, 'https://localhost:7275/Public/Images/HimalayaAshwagandha.jpg', '2024-01-01', '2025-01-01', 11, 11),
('Dabur Chyawanprash', 'Health supplement for immunity.', 300.00, 'https://localhost:7275/Public/Images/DaburChyawanprash.jpg', '2024-02-01', '2025-02-01', 11, 8),
('Himalaya Neem Face Wash', 'Purifies skin and fights acne.', 120.00, 'https://localhost:7275/Public/Images/HimalayaFaceWash.jpg', '2024-04-01', '2025-04-01', 12, 11),
('Mamaearth Vitamin C Serum', 'Brightening and anti-aging serum.', 600.00, 'https://localhost:7275/Public/Images/MamaearthSerum.jpg', '2024-03-01', '2025-03-01', 12, 13),
('Bikaji Rasgulla', 'Soft and spongy rasgullas.', 250.00, 'https://localhost:7275/Public/Images/BikajiRasgulla.jpg', '2024-05-01', '2025-05-01', 13, 12),
('Haldirams'' Gulab Jamun', 'Sweet and juicy gulab jamuns.', 300.00, 'https://localhost:7275/Public/Images/HaldiramsGulabJamun.jpg', '2024-06-01', '2025-06-01', 13, 7),
('Horlicks Health Drink', 'Nutritious malt-based drink.', 400.00, 'https://localhost:7275/Public/Images/Horlicks.jpg', '2024-07-01', '2025-07-01', 14, 5),
('Bournvita', 'Chocolate health drink.', 380.00, 'https://localhost:7275/Public/Images/Bournvita.jpg', '2024-08-01', '2025-08-01', 14, 5),
('Cycle Pure Agarbatti', 'Premium incense sticks.', 50.00, 'https://localhost:7275/Public/Images/CycleAgarbatti.jpg', '2024-09-01', '2025-09-01', 15, 9),
('Fogg Agarbatti', 'Soothing incense sticks for prayer.', 60.00, 'https://localhost:7275/Public/Images/FoggAgarbatti.jpg', '2024-10-01', '2025-10-01', 15, 12),
('Yummiez Chicken Nuggets', 'Delicious frozen chicken nuggets.', 250.00, 'https://localhost:7275/Public/Images/YummiezChickenNuggets.jpg', '2024-11-01', '2025-11-01', 16, 15),
('Yummiez French Fries', 'Crispy frozen french fries.', 150.00, 'https://localhost:7275/Public/Images/YummiezFrenchFries.jpg', '2024-12-01', '2025-12-01', 16, 15),
('Everest Turmeric Powder', 'Pure turmeric powder.', 45.00, 'https://localhost:7275/Public/Images/EverestTurmeric.jpg', '2024-03-01', '2025-03-01', 3, 15),
('Everest Red Chilli Powder', 'Authentic red chilli powder.', 55.00, 'https://localhost:7275/Public/Images/EverestChilli.jpg', '2024-04-01', '2025-04-01', 3, 15),
('Saffola Gold', 'Refined rice bran and sunflower oil.', 200.00, 'https://localhost:7275/Public/Images/SaffolaGold.jpg', '2024-05-01', '2025-05-01', 5, 15),
('Dalda Vanaspati', 'High-quality vanaspati oil.', 180.00, 'https://localhost:7275/Public/Images/Dalda.jpg', '2024-06-01', '2025-06-01', 5, 13),
('Nandini Butter', 'Delicious creamy butter.', 60.00, 'https://localhost:7275/Public/Images/NandiniButter.jpg', '2024-09-01', '2025-09-01', 7, 13),
('Tata Tea Premium', 'Rich blend of Assam teas.', 220.00, 'https://localhost:7275/Public/Images/TataTea.jpg', '2024-10-01', '2025-10-01', 8, 3),
('Bru Instant Coffee', 'Rich and aromatic instant coffee.', 350.00, 'https://localhost:7275/Public/Images/BruCoffee.jpg', '2024-11-01', '2025-11-01', 8, 10),
('Dabur Triphala Churna', 'Herbal remedy for digestion.', 120.00, 'https://localhost:7275/Public/Images/Triphala.jpg', '2024-01-01', '2025-01-01', 11, 8),
('Himalaya Brahmi', 'Memory and concentration booster.', 140.00, 'https://localhost:7275/Public/Images/Brahmi.jpg', '2024-02-01', '2025-02-01', 11, 11),
('Mamaearth Onion Hair Oil', 'Promotes hair growth.', 400.00, 'https://localhost:7275/Public/Images/OnionHairOil.jpg', '2024-03-01', '2025-03-01', 12, 13),
('Patanjali Aloe Vera Gel', 'Natural and soothing aloe vera gel.', 100.00, 'https://localhost:7275/Public/Images/AloeGel.jpg', '2024-04-01', '2025-04-01', 12, 9),
('Boost Health Drink', 'Energy drink for kids.', 250.00, 'https://localhost:7275/Public/Images/Boost.jpg', '2024-07-01', '2025-07-01', 14, 10),
('Complan', 'Nutrition for growing children.', 280.00, 'https://localhost:7275/Public/Images/Complan.jpg', '2024-08-01', '2025-08-01', 14, 10),
('Mangaldeep Agarbatti', 'Divine fragrance incense sticks.', 40.00, 'https://localhost:7275/Public/Images/Mangaldeep.jpg', '2024-09-01', '2025-09-01', 15, 15),
('Zed Black Dhoop Sticks', 'Aromatic dhoop sticks for puja.', 50.00, 'https://localhost:7275/Public/Images/ZedBlackDhoop.jpg', '2024-10-01', '2025-10-01', 15, 9),
('McCain Aloo Tikki', 'Crispy frozen potato tikkis.', 120.00, 'https://localhost:7275/Public/Images/McCainAlooTikki.png', '2024-11-01', '2025-11-01', 16, 12),
('Yummiez Chicken Sausages', 'Frozen chicken sausages.', 300.00, 'https://localhost:7275/Public/Images/YummiezChickenSausages.jpg', '2024-12-01', '2025-12-01', 16, 15),
('Fresh Mangoes', 'Delicious Alphonso mangoes.', 250.00, 'https://localhost:7275/Public/Images/Mangoes.jpg', '2024-05-01', '2025-05-15', 9, 19),
('Fresh Apples', 'Crisp and juicy apples.', 180.00, 'https://localhost:7275/Public/Images/Apples.jpg', '2024-05-01', '2025-05-15', 9, 19),
('Kohinoor Basmati Rice', 'Fragrant and long grain basmati rice.', 1350.00, 'https://localhost:7275/Public/Images/KohinoorRice.jpg', '2024-01-01', '2025-01-01', 1, 14),
('India Gate Classic Basmati', 'Premium aged basmati rice.', 1500.00, 'https://localhost:7275/Public/Images/IndiaGateClassic.jpg', '2024-01-01', '2025-01-01', 1, 14),
('Tata Moong Dal', 'High-quality moong dal.', 140.00, 'https://localhost:7275/Public/Images/TataMoongDal.jpg', '2024-02-01', '2025-02-01', 2, 3),
('Everest Coriander Powder', 'Pure coriander powder.', 40.00, 'https://localhost:7275/Public/Images/EverestCoriander.jpg', '2024-04-01', '2025-04-01', 3, 15),
('Catch Jeera Powder', 'Fresh and aromatic cumin powder.', 65.00, 'https://localhost:7275/Public/Images/CatchJeera.jpg', '2024-05-01', '2025-05-01', 3, 15),
('Shakti Bhog Atta', 'Whole wheat flour for healthy chapatis.', 250.00, 'https://localhost:7275/Public/Images/ShaktiBhogAtta.jpg', '2024-03-01', '2025-03-01', 4, 14),
('Patanjali Wheat Atta', 'Natural whole wheat flour.', 280.00, 'https://localhost:7275/Public/Images/PatanjaliAtta.jpg', '2024-03-01', '2025-03-01', 4, 9),
('Sundrop Refined Oil', 'Light and healthy sunflower oil.', 220.00, 'https://localhost:7275/Public/Images/SundropOil.jpg', '2024-05-01', '2025-05-01', 5, 12),
('Kurkure Masala Munch', 'Spicy and crunchy snacks.', 25.00, 'https://localhost:7275/Public/Images/KurkureMasala.jpg', '2024-07-01', '2025-07-01', 6, 12),
('Mother Dairy Paneer', 'Fresh and soft paneer.', 90.00, 'https://localhost:7275/Public/Images/MotherDairyPaneer.jpg', '2024-09-01', '2025-09-01', 7, 16),
('Gowardhan Ghee', 'Pure and fresh cow ghee.', 500.00, 'https://localhost:7275/Public/Images/GowardhanGhee.jpg', '2024-08-01', '2025-08-01', 7, 17),
('Red Label Tea', 'Rich and full-bodied black tea.', 250.00, 'https://localhost:7275/Public/Images/RedLabel.jpg', '2024-10-01', '2025-10-01', 8, 14),
('Nescafe Classic', 'Instant coffee with a rich aroma.', 360.00, 'https://localhost:7275/Public/Images/NescafeClassic.jpg', '2024-11-01', '2025-11-01', 8, 10),
('Patanjali Giloy Juice', 'Boosts immunity and overall health.', 180.00, 'https://localhost:7275/Public/Images/PatanjaliGiloy.jpg', '2024-02-01', '2025-02-01', 11, 9),
('Biotique Neem Face Wash', 'Natural neem face cleanser.', 120.00, 'https://localhost:7275/Public/Images/BiotiqueNeemFaceWash.jpg', '2024-03-01', '2025-03-01', 12, 15),
('Lotus Herbals Sunscreen', 'Herbal sunscreen with SPF 50.', 350.00, 'https://localhost:7275/Public/Images/LotusSunscreen.jpg', '2024-04-01', '2025-04-01', 12, 17),
('McCain French Fries', 'Frozen crispy French fries.', 150.00, 'https://localhost:7275/Public/Images/McCainFries.jpg', '2024-11-01', '2025-11-01', 16, 18),
('Fresh Bananas', 'Fresh and ripe bananas.', 40.00, 'https://localhost:7275/Public/Images/Bananas.jpg', '2024-05-01', '2025-05-15', 9, 19),
('Fresh Grapes', 'Juicy green seedless grapes.', 180.00, 'https://localhost:7275/Public/Images/Grapes.jpg', '2024-05-01', '2025-05-15', 9, 19);

--new
INSERT INTO Products (name, description, price, pictureUrl, mfgDate, expDate, productTypeId, productBrandId) VALUES

('Amul Milk', 'Full cream milk.', 55.00, 'https://localhost:7275/Public/Images/amulMilk.jpg', '2024-12-01', '2025-12-01', 7, 6),
('Haldiram''s Kaju Katli', 'Premium quality cashew sweets.', 500.00, 'https://localhost:7275/Public/Images/kajuKatli.jpg', '2024-01-01', '2025-01-01', 14, 7),
('Himalaya Baby Cream', 'Gentle cream for baby skin.', 120.00, 'https://localhost:7275/Public/Images/himalayaBabyCream.jpg', '2024-05-01', '2025-05-01', 12, 11),
('Haldiram''s Soan Papdi', 'Mouth-melting Indian sweet.', 100.00, 'https://localhost:7275/Public/Images/soanPapdi.jpg', '2024-05-01', '2025-05-01', 14, 7),
('Parle Hide & Seek Biscuits', 'Choco chip biscuits.', 50.00, 'https://localhost:7275/Public/Images/hideAndSeek.jpg', '2024-11-01', '2025-11-01', 6, 5),
('Mamaearth Shampoo', 'Natural hair care solution.', 300.00, 'https://localhost:7275/Public/Images/mamaearthShampoo.jpg', '2024-04-01', '2025-04-01', 12, 14),
('Emami Hair Oil', 'Ayurvedic hair oil for healthy hair.', 200.00, 'https://localhost:7275/Public/Images/emamiHairOil.jpg', '2024-05-01', '2025-05-01', 12, 15),
('Britannia Milk Bikis', 'Milk cream biscuits.', 45.00, 'https://localhost:7275/Public/Images/milkBikis.jpg', '2024-04-01', '2025-04-01', 6, 10);


DELETE FROM Products;
 
Select * from Products

INSERT INTO ProductTypes  VALUES

('Rice'),

('Pulses'),

('Spices'),

('Flours'),

('Oils'),

('Snacks'),

( 'Dairy'),

('Beverages'),

('Fruits'),

('Vegetables')
INSERT INTO ProductTypes VALUES
('Ayurvedic Products'),
('Herbal Cosmetics'),
('Packaged Sweets'),
('Health Drinks'),
('Incense and Puja Items'),
('Frozen food');


Select * from ProductTypes
 
 --- 20 brand
 --- 15 type
 --- 100 product
 
 
INSERT INTO ProductBrands VALUES

('Fortune'),

('MDH'),

('Tata'),

('Aashirvaad'),

( 'Parle'),

( 'Amul'),

( 'Haldiram''s'),

( 'Dabur'),

( 'Patanjali'),

( 'Britannia');
INSERT INTO ProductBrands VALUES
('Himalaya'),
('Bikaji'),
('Fogg'),
('Mamaearth'),
('Emami'),
('yummiez');
INSERT INTO ProductBrands VALUES
('Lotus'),
('McCain')
INSERT INTO ProductBrands VALUES
('Farms')




 
 
Drop table ProductBrands

Drop table ProductTypes

Drop table Products
 
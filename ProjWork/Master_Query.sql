use GrocQuick

select * from Products
select * from ProductTypes
select * from ProductBrands
select * from Users
select * from Address
select * from BasketItems
select * from CustomersBaskets
select * from DeliveryMethods
select * from OrderedItems
select * from Orders

INSERT INTO Products (name, description, price, pictureUrl, productTypeId, productBrandId) VALUES
('Fortune Basmati Rice', 'Premium quality basmati rice.', 
1200.00, '/Public/Images/BasmatiRice.png', 1, 1)

 

INSERT INTO Products (name, description, price, pictureUrl, mfgDate, expDate, productTypeId, productBrandId) VALUES
('MDH Chana Masala', 'Spicy and flavorful chana masala.', 50.00, 'https://localhost:7275/Public/Images/mdhChana.png', '2024-01-01', '2025-01-01', 3, 2),
('Tata Salt', 'Iodized salt for daily use.', 20.00, 'https://localhost:7275/Public/Images/TataSalt.png', '2024-02-01', '2025-02-01', 3, 3),
('Aashirvaad Atta', 'Whole wheat flour for soft chapatis.', 300.00, 'https://localhost:7275/Public/Images/aashAtta.png', '2024-03-01', '2025-03-01', 4, 4),
('Parle G Biscuits', 'Classic glucose biscuits.', 40.00, 'https://localhost:7275/Public/Images/ParleG.png', '2024-04-01', '2025-04-01', 6, 5),
('Amul Butter', 'Creamy and delicious butter.', 50.00, 'https://localhost:7275/Public/Images/amulButter.png', '2024-05-01', '2025-05-01', 7, 6),
('Haldiram''s Bhujia', 'Crispy and spicy bhujia.', 100.00, 'https://localhost:7275/Public/Images/Haldirams.png', '2024-06-01', '2025-06-01', 6, 7),
('Dabur Honey', 'Pure and natural honey.', 200.00, 'https://localhost:7275/Public/Images/daburHoney.png', '2024-07-01', '2025-07-01', 8, 8),
('Patanjali Ghee', 'Pure cow ghee.', 500.00, 'https://localhost:7275/Public/Images/PatanjaliGhee.png', '2024-08-01', '2025-08-01', 5, 9),
('Britannia Cheese', 'Delicious and creamy cheese slices.', 150.00, 'https://localhost:7275/Public/Images/BritanniaCheese.png', '2024-09-01', '2025-09-01', 7, 10);

 

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
('Vegetables');
Select * from ProductTypes

 

 

 

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


insert into DeliveryMethods values
('Free','Delivery of product within a week',0),
('DV1','Delivery of product within 4 days',15),
('DV2','Delivery of product within 2 days',30),
('DV3','Delivery of product within 1 days',40),
('DV4','Delivery of product within 12 hr',50)


INSERT INTO ProductBrands VALUES

('Fortune'),

('MDH'),

('Tata'),

( 'Amul'),

( 'Haldiram''s'),

( 'Dabur'),

('Himalaya'),

('yummiez'),

('McCain'),

('Farms'),

('Basmati'),

('Everest');


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

('Vegetables'),

('Frozen food');


INSERT INTO Products (name, description, price, pictureUrl, mfgDate, expDate, productTypeId, productBrandId) VALUES
('Fortune Basmati Rice', 'Premium quality basmati rice.', 1200.00, 'https://localhost:7275/Public/Public/Images/BasmatiRice.png','2024-01-01', '2025-01-01', 1, 1),

('MDH Chana Masala', 'Spicy and flavorful chana masala.', 50.00, 'https://localhost:7275/Public/Images/mdhChana.png', '2024-01-01', '2025-01-01', 3, 2),

('Tata Salt', 'Iodized salt for daily use.', 20.00, 'https://localhost:7275/Public/Images/TataSalt.png', '2024-02-01', '2025-02-01', 3, 3),

('Amul Butter', 'Creamy and delicious butter.', 50.00, 'https://localhost:7275/Public/Images/amulButter.png', '2024-05-01', '2025-05-01', 7, 4),

('Haldiram''s Bhujia', 'Crispy and spicy bhujia.', 100.00, 'https://localhost:7275/Public/Images/Haldirams.png', '2024-06-01', '2025-06-01', 6, 5),

('Dabur Honey', 'Pure and natural honey.', 200.00, 'https://localhost:7275/Public/Images/daburHoney.png', '2024-07-01', '2025-07-01', 8, 6),
('Tata Sona Masoori Rice', 'High-quality masoori rice.', 1000.00, 'https://localhost:7275/Public/Images/SonaMasoori.jpg', '2024-01-01', '2025-01-01', 1, 3),

 ('Fortune Toor Dal', 'Premium quality toor dal.', 150.00, 'https://localhost:7275/Public/Images/ToorDal.jpg', '2024-01-01', '2025-01-01', 2, 1),
 ('Tata Urad Dal', 'High-quality urad dal.', 140.00, 'https://localhost:7275/Public/Images/UradDal.jpg', '2024-01-01', '2025-01-01', 2, 3),
 ('MDH Garam Masala', 'Authentic garam masala.', 70.00, 'https://localhost:7275/Public/Images/mdhGaram.jpg', '2024-01-01', '2025-01-01', 3, 2),
 ('Fortune Sunflower Oil', 'Refined sunflower oil.', 180.00, 'https://localhost:7275/Public/Images/SunflowerOil.jpg', '2024-05-01', '2025-05-01', 5, 1),
('Haldirams'' Gulab Jamun', 'Sweet and juicy gulab jamuns.', 300.00, 'https://localhost:7275/Public/Images/HaldiramsGulabJamun.jpg', '2024-06-01', '2025-06-01', 6, 5),
('Yummiez Chicken Nuggets', 'Delicious frozen chicken nuggets.', 250.00, 'https://localhost:7275/Public/Images/YummiezChickenNuggets.jpg', '2024-11-01', '2025-11-01', 11, 8),
('Yummiez French Fries', 'Crispy frozen french fries.', 150.00, 'https://localhost:7275/Public/Images/YummiezFrenchFries.jpg', '2024-12-01', '2025-12-01', 11, 8),
('Everest Turmeric Powder', 'Pure turmeric powder.', 45.00, 'https://localhost:7275/Public/Images/EverestTurmeric.jpg', '2024-03-01', '2025-03-01', 3, 12),
('Everest Red Chilli Powder', 'Authentic red chilli powder.', 55.00, 'https://localhost:7275/Public/Images/EverestChilli.jpg', '2024-04-01', '2025-04-01', 3, 12),
('Tata Tea Premium', 'Rich blend of Assam teas.', 220.00, 'https://localhost:7275/Public/Images/TataTea.jpg', '2024-10-01', '2025-10-01', 8, 3),
('McCain Aloo Tikki', 'Crispy frozen potato tikkis.', 120.00, 'https://localhost:7275/Public/Images/McCainAlooTikki.png', '2024-11-01', '2025-11-01', 11, 9),
('Yummiez Chicken Sausages', 'Frozen chicken sausages.', 300.00, 'https://localhost:7275/Public/Images/YummiezChickenSausages.jpg', '2024-12-01', '2025-12-01', 11, 8),
('Fresh Mangoes', 'Delicious Alphonso mangoes.', 250.00, 'https://localhost:7275/Public/Images/Mangoes.jpg', '2024-05-01', '2025-05-15', 9, 10),
('Fresh Apples', 'Crisp and juicy apples.', 180.00, 'https://localhost:7275/Public/Images/Apples.jpg', '2024-05-01', '2025-05-15', 9, 10),
('Kohinoor Basmati Rice', 'Fragrant and long grain basmati rice.', 1350.00, 'https://localhost:7275/Public/Images/KohinoorRice.jpg', '2024-01-01', '2025-01-01', 1, 11),
('India Gate Classic Basmati', 'Premium aged basmati rice.', 1500.00, 'https://localhost:7275/Public/Images/IndiaGateClassic.jpg', '2024-01-01', '2025-01-01', 1, 11),
('Tata Moong Dal', 'High-quality moong dal.', 140.00, 'https://localhost:7275/Public/Images/TataMoongDal.jpg', '2024-02-01', '2025-02-01', 2, 3),
('Everest Coriander Powder', 'Pure coriander powder.', 40.00, 'https://localhost:7275/Public/Images/EverestCoriander.jpg', '2024-04-01', '2025-04-01', 3, 12),
('Catch Jeera Powder', 'Fresh and aromatic cumin powder.', 65.00, 'https://localhost:7275/Public/Images/CatchJeera.jpg', '2024-05-01', '2025-05-01', 3, 12),
('McCain French Fries', 'Frozen crispy French fries.', 150.00, 'https://localhost:7275/Public/Images/McCainFries.jpg', '2024-11-01', '2025-11-01', 11, 9),
('Fresh Bananas', 'Fresh and ripe bananas.', 40.00, 'https://localhost:7275/Public/Images/Bananas.jpg', '2024-05-01', '2025-05-15', 9, 10),
('Fresh Grapes', 'Juicy green seedless grapes.', 180.00, 'https://localhost:7275/Public/Images/Grapes.jpg', '2024-05-01', '2025-05-15', 9, 10),
('Amul Milk', 'Full cream milk.', 55.00, 'https://localhost:7275/Public/Images/amulMilk.jpg', '2024-12-01', '2025-12-01', 7, 4),
('Haldiram''s Kaju Katli', 'Premium quality cashew sweets.', 500.00, 'https://localhost:7275/Public/Images/kajuKatli.jpg', '2024-01-01', '2025-01-01', 6, 7),
('Haldiram''s Soan Papdi', 'Mouth-melting Indian sweet.', 100.00, 'https://localhost:7275/Public/Images/soanPapdi.jpg', '2024-05-01', '2025-05-01', 6, 7);
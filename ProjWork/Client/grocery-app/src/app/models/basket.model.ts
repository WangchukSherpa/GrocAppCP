
  
  export interface IBasket {
    Id: string;  // Basket Id
    Items: IBasketItem[];  // Array of basket items
    ClientSecret?:string;
    PaymentIntendId?:string;
    DeliveryMethodId?:string;
}

export interface IBasketItem {
    Id: number;  // Product Id
    ProductName: string;  // Name of the product
    Price: number;  // Price of the product
    Quantity: number;  // Quantity of the product in the basket
    PictureUrl: string;  // URL of the product image
    Brand: string;  // Brand of the product
    Type: string;  // Type or category of the product
    customersBasketId: string;  // Id of the associated customer's basket
}
// export interface IBasketPost {
//   ProductName: string;  // Name of the product
//   Price: number;  // Price of the product
//   Quantity: number;  // Quantity of the product in the basket
//   PictureUrl: string;  // URL of the product image
//   Brand: string;  // Brand of the product
//   Type: string;  // Type or category of the product
//   customersBasketId: string;  // Id of the associated customer's basket
// }
// export interface IPost {
//   Id: string;  // Basket Id
//   Items: IBasketPost[];  // Array of basket items
// }

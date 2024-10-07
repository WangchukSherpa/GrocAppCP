export interface IBasket {
    Id: string
    Items: IBasketItem[]
  }
  
  export interface IBasketItem {
    Id: number
    ProductName: string
    Price: number
    Quantity: number
    PictureUrl: string
    Brand: string
    Type: string
    CustomersBasketId: string
    CustomersBasket: string
  }
  

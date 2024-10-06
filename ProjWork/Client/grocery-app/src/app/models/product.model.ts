

export interface IProduct {
  Name: string
  Description: string
  Price: number
  PictureUrl: string
  MfgDate: string
  ExpDate: string
  ProductType: IProductType
  ProductTypeId: number
  ProductBrand: IProductBrand
  ProductBrandId: number
  Id: number
}

export interface IProductType {
  Name: string
  Id: number
}

export interface IProductBrand {
  Name: string
  Id: number
}

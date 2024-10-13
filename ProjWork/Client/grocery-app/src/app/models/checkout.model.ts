export interface Checkout {
    BasketId: string;
    DeliveryMethodId: number;
    shiptoAddress: {
      FlatHouseNo: string;
      AreaSector: string;
      LandMark: string;
      Pincode: number;
      City: string;
      State: string;
    };
  }
  
import { ShoppingCartItemDTO } from "./shopping-cart-item.DTO";

export class ShoppingCartDTO {
  public id?: string;
  public costumerId?: string;
  public total: number;
  public items: ShoppingCartItemDTO[];

  /**
   *
   */
  constructor() {
    this.total = 0;
    this.items = [ {quantity: 1, productId: "12", price: 123, name: "teste", imagePath: ""}];
  }
}

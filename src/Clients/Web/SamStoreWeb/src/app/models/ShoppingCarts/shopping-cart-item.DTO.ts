export class ShoppingCartItemDTO {
  public id?: string;
  public cartId?: string;
  public productId: string;
  public name: string;
  public quantity: number = 1;
  public price: number = 0;
  public imagePath: string = "";

  /**
   *
   */
  constructor(productId: string, name: string) {
    this.productId = productId;
    this.name = name;
  }
}

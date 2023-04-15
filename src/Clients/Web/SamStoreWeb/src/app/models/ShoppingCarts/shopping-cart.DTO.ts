import { ShoppingCartItemDTO } from "./shopping-cart-item.DTO";

export class ShoppingCartDTO {
	public id?: string = "";
	public costumerId?: string = "";
	public total: number = 0;
	public items: ShoppingCartItemDTO[] = [];
}

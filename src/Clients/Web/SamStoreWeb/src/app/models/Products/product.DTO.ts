import { ProductRatingDTO } from "./product-rating.DTO";

export interface ProductDTO {
	id: string;
	name: string;
	description: string;
	value: number;
	image: string;
	quantity: number;
	ref: string;
	productRating: ProductRatingDTO;
}

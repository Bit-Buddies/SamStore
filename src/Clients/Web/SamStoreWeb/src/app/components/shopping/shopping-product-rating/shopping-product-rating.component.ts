import { Component, Input } from "@angular/core";
import { ProductRatingDTO } from "src/app/models/Products/product-rating.DTO";

@Component({
    selector: "app-shopping-product-rating",
    templateUrl: "./shopping-product-rating.component.html",
    styleUrls: ["./shopping-product-rating.component.scss"],
})
export class ShoppingProductRatingComponent {
    @Input() set setProductRating(productRating: ProductRatingDTO | undefined) {
        this._productRating = productRating || new ProductRatingDTO();
        this.calculateRating();
    }

    private _productRating: ProductRatingDTO = new ProductRatingDTO();
    private _rateAverage: number = 0;

    public totalVotes: number = 0;

    private _starEmpty: string = "star_border";
    private _starHalf: string = "star_half";
    private _starFull: string = "star";

    public star1: string = this._starEmpty;
    public star2: string = this._starEmpty;
    public star3: string = this._starEmpty;
    public star4: string = this._starEmpty;
    public star5: string = this._starEmpty;

    public calculateRating() {
        this.totalVotes =
            this._productRating.rating1Quantity +
            this._productRating.rating2Quantity +
            this._productRating.rating3Quantity +
            this._productRating.rating4Quantity +
            this._productRating.rating5Quantity;

        this._rateAverage = 0;

        if (this.totalVotes > 0) {
            const rateValue1 = this._productRating.rating1Quantity * 1;
            const rateValue2 = this._productRating.rating2Quantity * 2;
            const rateValue3 = this._productRating.rating3Quantity * 3;
            const rateValue4 = this._productRating.rating4Quantity * 4;
            const rateValue5 = this._productRating.rating5Quantity * 5;

            const totalRateValues = rateValue1 + rateValue2 + rateValue3 + rateValue4 + rateValue5;

            this._rateAverage = totalRateValues / this.totalVotes;
        }

        this.fillStars();
    }

    private fillStars() {
        const avg = this._rateAverage;

        this.star1 = this._starEmpty;
        this.star2 = this._starEmpty;
        this.star3 = this._starEmpty;
        this.star4 = this._starEmpty;
        this.star5 = this._starEmpty;

        if (avg > 0 && avg < 1) this.star1 = this._starHalf;

        if (avg >= 1) this.star1 = this._starFull;

        if (avg > 1 && avg < 2) this.star2 = this._starHalf;

        if (avg >= 2) this.star2 = this._starFull;

        if (avg > 2 && avg < 3) this.star3 = this._starHalf;

        if (avg >= 3) this.star3 = this._starFull;

        if (avg > 3 && avg < 4) this.star4 = this._starHalf;

        if (avg >= 4) this.star4 = this._starFull;

        if (avg > 4 && avg < 5) this.star5 = this._starHalf;

        if (avg >= 5) this.star5 = this._starFull;
    }
}

import { Injectable, inject } from "@angular/core";
import { ActivatedRouteSnapshot, CanActivate, CanDeactivate, RouterStateSnapshot, UrlTree } from "@angular/router";
import { Observable } from "rxjs";
import { NavbarService } from "../services/navbar.service";

export const hideNavbarGuard = () => {
    const navbarService = inject(NavbarService);

    navbarService.hide();

    return true;
}

export const showNavbarGuard = () => {
    const navbarService = inject(NavbarService);

    navbarService.show();

    return true;
}
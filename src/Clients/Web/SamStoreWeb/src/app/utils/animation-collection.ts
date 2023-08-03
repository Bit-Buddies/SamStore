import {
    animate,
    keyframes,
    query,
    stagger,
    state,
    style,
    transition,
    trigger,
} from "@angular/animations";

export const fadeAnimation = (timing: string) =>
    trigger(
        'fade', [
        transition(':enter', [
            style({ opacity: 0}),
            animate(timing, style({ opacity: 1 }))
        ]),
        transition(':leave', [
            style({opacity: 1}),
            animate(timing, style({opacity: 0}))
        ])])

export const staggerAnimation = (delay: string) =>
    trigger("stagger", [
        transition("* <=> *", [
            query(":enter", [
                style({ opacity: 0 }),
                stagger(delay, [
                    animate(
                        "450ms cubic-bezier(0.79,0.14,0.15,0.86)",
                        style({opacity: 1}),
                    ),
                ])
            ], { optional: true }),
            query(':leave',
                animate("250ms cubic-bezier(0.79,0.14,0.15,0.86)", style(
                    { 
                        opacity: 0,
                        transform: "scale(0.95, 0.2)"
                    })),
                { optional: true})
            ]),
    ]);

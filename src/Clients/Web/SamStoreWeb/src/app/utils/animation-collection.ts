import {
    AnimationTriggerMetadata,
    animate,
    keyframes,
    query,
    stagger,
    state,
    style,
    transition,
    trigger,
} from "@angular/animations";

export const fadeAnimation = (timing: string) : AnimationTriggerMetadata =>
    trigger(
        'fade', [
        transition(':enter', [
            style({ opacity: 0, transform: "translateY(12px)"}),
            animate(timing, style({ opacity: 1, transform: "translateY(0px)" }))
        ]),
        transition(':leave', [
            style({opacity: 1}),
            animate(timing, style({opacity: 0}))
        ])])

export const staggerAnimation = (delay: string) : AnimationTriggerMetadata =>
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
                        transform: "translateY(12px)"
                    })),
                { optional: true})
            ]),
    ]);

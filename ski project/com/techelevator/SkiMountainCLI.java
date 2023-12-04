package com.techelevator;

import com.techelevator.view.Menu;

import java.awt.*;
import java.sql.SQLOutput;
import java.util.Scanner;
import java.util.function.ToDoubleBiFunction;

public class SkiMountainCLI {

    private static final String MAIN_MENU_OPTION_DISPLAY_SLOPES = "Display list of all slopes";
    private static final String MAIN_MENU_OPTION_SLOPE_INFO = "Get info about slopes";
    private static final String MAIN_MENU_OPTION_EXIT = "Exit";
    private static final String[] MAIN_MENU_OPTIONS = { MAIN_MENU_OPTION_DISPLAY_SLOPES, MAIN_MENU_OPTION_SLOPE_INFO, MAIN_MENU_OPTION_EXIT};


    private static final String SLOPE_INFO_MENU_OPTION_LIST_SLOPES_BY_DIFFICULTY = "Display all slopes of chosen difficulty level";
    private static final String SLOPE_INFO_MENU_OPTION_LIST_DIFFICULTY_BY_SLOPE_NAME = "Show difficulty level of a certain slope";
    private static final String SLOPE_INFO_MENU_OPTION_BACK_TO_MAIN = "Back to main menu";
    private static final String[] SLOPE_INFO_MENU_OPTIONS = { SLOPE_INFO_MENU_OPTION_LIST_SLOPES_BY_DIFFICULTY, SLOPE_INFO_MENU_OPTION_LIST_DIFFICULTY_BY_SLOPE_NAME, SLOPE_INFO_MENU_OPTION_BACK_TO_MAIN};

    private static final String SLOPE_INFO_MENU_A_OPTION_LIST_ALL_GREEN_CIRCLE_SLOPES = "Display all beginner slopes";
    private static final String SLOPE_INFO_MENU_A_OPTION_LIST_ALL_BLUE_SQUARE_SLOPES = "Display all more difficult slopes";
    private static final String SLOPE_INFO_MENU_A_OPTION_LIST_ALL_BLACK_DIAMOND_SLOPES = "Display all most difficult slopes";
    private static final String SLOPE_INFO_MENU_A_OPTION_LIST_ALL_DOUBLE_BLACK_DIAMOND_SLOPES = "Display all expert slopes";
    private static final String SLOPE_INFO_MENU_A_OPTION_LIST_ALL_TERRAIN_PARKS = "Display all terrain parks";
    private static final String[] SLOPE_INFO_MENU_A_OPTIONS = {SLOPE_INFO_MENU_A_OPTION_LIST_ALL_GREEN_CIRCLE_SLOPES, SLOPE_INFO_MENU_A_OPTION_LIST_ALL_BLUE_SQUARE_SLOPES, SLOPE_INFO_MENU_A_OPTION_LIST_ALL_BLACK_DIAMOND_SLOPES, SLOPE_INFO_MENU_A_OPTION_LIST_ALL_DOUBLE_BLACK_DIAMOND_SLOPES, SLOPE_INFO_MENU_A_OPTION_LIST_ALL_TERRAIN_PARKS};

    private SlopeListBuilder slopeListBuilder = new SlopeListBuilder();
    private SlopeList slopeList = slopeListBuilder.build();


    private Menu menu;
    Scanner userInput = new Scanner(System.in);


    public static void main(String[] args) {
        Menu menu = new Menu(System.in, System.out);
        SkiMountainCLI cli = new SkiMountainCLI(menu);
        cli.run();
    }

    public SkiMountainCLI(Menu menu) {
        this.menu = menu;
    }

    public void run() {
        while (true) {
            String choice = (String) menu.getChoiceFromOptions(MAIN_MENU_OPTIONS);

            if (choice.equals((MAIN_MENU_OPTION_DISPLAY_SLOPES))) {

                 for (SkiSlope slope : slopeList.getSlopeList()) {
                     System.out.println(slope);
                 }

            } else if (choice.equals(MAIN_MENU_OPTION_SLOPE_INFO)) {
                 slopeInfoMenu();
            } else if (choice.equals(MAIN_MENU_OPTION_EXIT)) {
                System.out.println("Thank you, have fun shredding!");
                break;
            }
        }
    }

    private void slopeInfoMenu() {
        while (true) {
            String choice = (String) menu.getChoiceFromOptions(SLOPE_INFO_MENU_OPTIONS);
            if (choice.equals(SLOPE_INFO_MENU_OPTION_LIST_SLOPES_BY_DIFFICULTY)) {
                slopeInfoMenuA();
            } else if (choice.equals(SLOPE_INFO_MENU_OPTION_LIST_DIFFICULTY_BY_SLOPE_NAME)) {
                // TODO: getSlopeDifficulty();
            } else if (choice.equals(SLOPE_INFO_MENU_OPTION_BACK_TO_MAIN)) {
                // TODO: get back to main menu
                break;
            }
        }
    }

    private void slopeInfoMenuA() {
        while (true) {
            String choice = (String) menu.getChoiceFromOptions(SLOPE_INFO_MENU_A_OPTIONS);
            if (choice.equals(SLOPE_INFO_MENU_A_OPTION_LIST_ALL_GREEN_CIRCLE_SLOPES)) {
                for (SkiSlope slope : slopeList.getSlopeList()) {
                    if (slope.getSlopeType().equals("Green Circle")) {
                        System.out.println(slope);
                    }
                }
            } else if (choice.equals(SLOPE_INFO_MENU_A_OPTION_LIST_ALL_BLUE_SQUARE_SLOPES)) {
                for (SkiSlope slope : slopeList.getSlopeList()) {
                    if (slope.getSlopeType().equals("Blue Square")) {
                        System.out.println(slope);
                    }
                }
            } else if (choice.equals(SLOPE_INFO_MENU_A_OPTION_LIST_ALL_BLACK_DIAMOND_SLOPES)) {
                for (SkiSlope slope : slopeList.getSlopeList()) {
                    if (slope.getSlopeType().equals("Black Diamond")) {
                        System.out.println(slope);
                    }
                }
            } else if (choice.equals(SLOPE_INFO_MENU_A_OPTION_LIST_ALL_DOUBLE_BLACK_DIAMOND_SLOPES)) {
                for (SkiSlope slope : slopeList.getSlopeList()) {
                    if (slope.getSlopeType().equals("Double Black Diamond")) {
                        System.out.println(slope);
                    }
                }
            } else if (choice.equals(SLOPE_INFO_MENU_A_OPTION_LIST_ALL_TERRAIN_PARKS)) {
                for (SkiSlope slope : slopeList.getSlopeList()) {
                    if (slope.getSlopeType().equals("Terrain Park")) {
                        System.out.println(slope);
                    }
                }
                break;
            }

        }
    }

}

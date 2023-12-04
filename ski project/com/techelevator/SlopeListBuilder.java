package com.techelevator;

import java.io.File;
import java.io.FileNotFoundException;
import java.util.Scanner;

public class SlopeListBuilder {

    public SlopeList build() {
        SlopeList slopeList = new SlopeList();
        File sevenSpringsSlopeListFile = new File("sevenspringsslopelist.csv");
        
        try (Scanner fileReader = new Scanner(sevenSpringsSlopeListFile)) {
            while (fileReader.hasNextLine()) {
                String line = fileReader.nextLine();
                SkiSlope skiSlope = parseLine(line);
                slopeList.addSkiSlope(skiSlope);
            }

        } catch (FileNotFoundException e) {
            
        }
        return slopeList;
    }
    
    private SkiSlope parseLine(String line) {
        String[] lineParts = line.split("\\|");
        
        String slopeName = lineParts[0];
        String slopeType = lineParts[1];

        if (slopeType.equals("Green Circle")) {
            GreenCircle greenSlope = new GreenCircle(slopeName, slopeType);
            return greenSlope;
        } else if (slopeType.equals("Blue Square")) {
            BlueSquare blueSquare = new BlueSquare(slopeName, slopeType);
            return blueSquare;
        } else if (slopeType.equals("Black Diamond")) {
            BlackDiamond blackDiamond = new BlackDiamond(slopeName, slopeType);
            return blackDiamond;
        } else if (slopeType.equals("Double Black Diamond")) {
            DoubleBlackDiamond doubleBlackSlope = new DoubleBlackDiamond(slopeName, slopeType);
            return doubleBlackSlope;
        } else {
            TerrainPark terrainPark = new TerrainPark(slopeName, slopeType);
            return terrainPark;
        }
        
    }
}

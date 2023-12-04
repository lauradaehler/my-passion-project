package com.techelevator;

public class SkiSlope {
    private String slopeName;
    private String slopeType;
    public SkiSlope (String slopeName, String slopeType) {
        this.slopeName = slopeName;
        this.slopeType = slopeType;
    }

    public String getSlopeName() {
        return slopeName;
    }

    public String getSlopeType() {
        return slopeType;
    }

    @Override
    public String toString() {
        String slopeInformation = slopeName + ": " + slopeType;
        return slopeInformation;
    }
}

package com.techelevator;

import java.util.ArrayList;
import java.util.List;

public class SlopeList {
    private final List<SkiSlope> slopeList = new ArrayList<>();

    public List<SkiSlope> getSlopeList() {
        return slopeList;
    }

    public void addSkiSlope(SkiSlope skislope) {
        slopeList.add(skislope);
    }
}

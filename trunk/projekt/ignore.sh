#!/bin/bash
# Change ingnorelist.txt to change the ignorelist for each folder, make sure to avioid whitespaces. 
cd .. 
svn -R propset svn:ignore -F projekt/ignorelist.txt .
svn up
svn ci -m "Auto Ignore commit from bash script"

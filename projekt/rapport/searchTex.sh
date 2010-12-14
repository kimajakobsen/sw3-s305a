echo "Searching on all .tex files in this directory and subdirectories in this folder on this term:" $1
grep -n -r -i $1 * --color --include="*.tex" 
 

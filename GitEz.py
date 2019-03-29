import subprocess as sb
import json as js
import sys as s

def printHelp():
    #print("-init: initializes json script for project execution\n")
    print("-update <repo>: initalizes a new json script, overwriting the previous\n")
    print("-auto <-stash=true/false> <commitMsg>: automatically pushes and pulls updating all repos,\n\t if you do not want your local changes to be overwritten because of a merge conflict you must stash your file, otherwise it will be deleted. \n\t Must supply a commit message\n")
    print("-createPersonal <nickname>: creates a personal repo with a set nickname for you to work in\n")
    print("-personal <nickname> <true/false>: sets the \"personal\" flag so you only work on your personal copy of the repo, defaults to main repository if nickname is not provided\n" )
    print("-repo: outputs current repo \n")
    print("-repos: print all repos, nicknames, and creation dates\n")
    print("-history: prints commit history\n")    
    return

def init(s):
    initFile = {}
    initFile["repositories"]=[]
    initFile["repositories"].append({
        "nickname":"main",
        "repo":s,
        "personal":"false",
        "CreationDate:":"_",
        "LastUpdated":"_"
    })

    with open('repo.json', 'w') as outfile:  
        js.dump(initFile, outfile)

    return

def auto(stash,msg):
    stashBool = False
    if stash == '-stash=true':
        stashBool = True
    sb.call(['git','stash'])
    sb.call(['git','pull'])
    sb.call(['git','add','.'])
    sb.call(['git','commit','-m',msg])
    sb.call(['git','push'])
    if stashBool == True:
        sb.call(['git','stash','pop'])
    else:
        sb.call(['git','stash','clear'])
    return

if len(s.argv) > 1:
    if s.argv[1] == "-help":
        printHelp()
    #elif s.argv[1] == "-init":
       # init(s.argv[2])
    elif s.argv[1] == "-auto":
        auto(s.argv[2],s.argv[3])

'''
How are combined communication tactics most often in the US, UK or Canada;
'''


import xml.etree.ElementTree as eT
from nltk.corpus.reader import XMLCorpusReader
from nltk.probability import FreqDist
from nltk.probability import ConditionalFreqDist
import itertools
from matplotlib import pylab


reader = XMLCorpusReader('', 'ExcusesSample.xml')
root = eT.fromstring(reader.raw())

tacticsListSorted = sorted(set([tactic.find('name').text for tactic in root.findall('./excuse/tactics/tactic')]))


def getMostUsedTacticCombinationsInCountry( countryName ):
    tacticsCombinationList = []
    for excuse in root.findall('./excuse'):
        if not excuse.find('country').text == countryName: continue

        excuseTacticNames = sorted([tactic.find('name').text for tactic in excuse.findall('tactics/tactic')])
        tacticIndexies = sorted([tacticsListSorted.index(name) for name in excuseTacticNames])
        if len(excuseTacticNames) >= 2:
            for combinationLength in range(2, len(tacticIndexies) + 1):
                tacticsCombinationList += tuple(itertools.combinations(tacticIndexies, combinationLength))

    dic = FreqDist(sorted(tacticsCombinationList))
    dic.plot(title='Most frequently used tactic combination for {0}'.format(countryName))
    return tacticsCombinationList

def getMostUsedTacticCombinations():
    tacticsCombinationList = []
    for excuse in root.findall('./excuse'):
        countryName = excuse.find('country').text
        excuseTacticNames = sorted([tactic.find('name').text for tactic in excuse.findall('tactics/tactic')])
        tacticIndexies = sorted([tacticsListSorted.index(name) for name in excuseTacticNames])
        if len(excuseTacticNames) >= 2:
            for combinationLength in range(2, len(tacticIndexies) + 1):
                for comb in itertools.combinations(tacticIndexies, combinationLength):
                    tacticsCombinationList.append((countryName, comb))
                    tacticsCombinationList.append(('all', comb))

    dic = ConditionalFreqDist(tacticsCombinationList)
    dic.plot(title='Most frequently used tactic combination in countries')
    return

for tacticName in tacticsListSorted:
    print('{0}: {1}'.format(tacticsListSorted.index(tacticName), tacticName))


#getMostUsedTacticCombinationsInCountry('USA')
#getMostUsedTacticCombinationsInCountry('UK')
#getMostUsedTacticCombinationsInCountry('Canada')
getMostUsedTacticCombinations()

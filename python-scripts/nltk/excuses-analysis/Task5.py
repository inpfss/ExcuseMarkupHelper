'''
 Які комунікативні тактики є найбільш часто вживаними в США, Великобританії чи Канаді
'''

import xml.etree.ElementTree as eT
from nltk.corpus.reader import XMLCorpusReader
from nltk.probability import FreqDist
import itertools
from matplotlib import pylab


reader = XMLCorpusReader('', 'ExcusesSample.xml')
root = eT.fromstring(reader.raw())

tacticsListSorted = sorted(set([tactic.find('name').text for tactic in root.findall('./excuse/tactics/tactic')]))


def getMostUsedTacticInCountry( countryName ):
    tacticsList = []
    for excuse in root.findall('./excuse'):
        if excuse.find('country').text == countryName:
            excuseTacticNames = sorted([tactic.find('name').text for tactic in excuse.findall('tactics/tactic')])
            tacticIndexies = sorted([tacticsListSorted.index(name) for name in excuseTacticNames])
            tacticsList += tacticIndexies

    dic = FreqDist(sorted(tacticsList))
    dic.plot(title='Most frequently used tactics for {0}'.format(countryName))
    return


for tacticName in tacticsListSorted:
    print('{0}: {1}'.format(tacticsListSorted.index(tacticName), tacticName))

getMostUsedTacticInCountry('USA')
getMostUsedTacticInCountry('UK')
getMostUsedTacticInCountry('Canada')

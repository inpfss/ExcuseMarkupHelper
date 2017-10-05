'''
 Статистика вибачень без визнання вини
'''

import xml.etree.ElementTree as eT
from nltk.corpus.reader import XMLCorpusReader
from nltk.probability import FreqDist
import itertools
from matplotlib import pylab


reader = XMLCorpusReader('', 'ExcusesSample.xml')
root = eT.fromstring(reader.raw())

mustHaveExcuseTactics = set(['Tactic #1', 'Tactic #3'])

statExcuses = FreqDist()
statNonExcuses = FreqDist()
for excuse in root.findall('./excuse'):
    countryName = excuse.find('country').text
    excuseTacticNames = [tactic.find('name').text for tactic in excuse.findall('tactics/tactic')]
    isExcuse = len(mustHaveExcuseTactics.intersection(excuseTacticNames)) > 0
    if isExcuse:
        statExcuses[countryName] += 1
        statExcuses['all'] += 1
    else:
        statNonExcuses[countryName] += 1
        statNonExcuses['all'] += 1

print(mustHaveExcuseTactics)

statExcuses.plot(title='Stat real excuses in countries')
statNonExcuses.plot(title='Non excuses in countries')
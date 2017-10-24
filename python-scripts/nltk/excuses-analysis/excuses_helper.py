'''
This module contains functions which are used in order to solve analysis of excuses
'''

# for xml
import xml.etree.ElementTree as eT
# xml reader
from nltk.corpus.reader import XMLCorpusReader


class ExcusesHelper:
    excusesXmlTree = None

    @property
    def country_path(self):
        return 'country'

    def __init__(self):
        # create object for reading excuses from file
        reader = XMLCorpusReader('', 'Excuses.xml')
        # read all excuses into memory as plain text, then create XML document from that string
        self.excusesXmlTree = eT.fromstring(reader.raw())

    def get_defined_tactics_indices(self):
        tactics_indices = [int(tactic.attrib['index']) for tactic in self.excusesXmlTree.findall('./tacticIndices/tactic')]
        return tactics_indices

    def get_defined_tactics(self):
        tactics = []
        for tactic in self.excusesXmlTree.findall('./tacticIndices/tactic'):
            tactics.append((tactic.attrib['index'], tactic.attrib['name']))
        return tactics

    def get_tactics_container_elements(self):
        elements = self.excusesXmlTree.findall('./excuses/excuse/communicativeTactics')
        return elements

    def get_tactics_elements(self):
        elements = self.excusesXmlTree.findall('./excuses/excuse/communicativeTactics/communicativeTactic')
        return elements

    def get_all_excuse_elements(self):
        elements = self.excusesXmlTree.findall('./excuses/excuse')
        return elements

    def get_author_countries(self):
        countries = set([c.text for c in self.excusesXmlTree.findall('./excuses/excuse/country')])
        return countries

    @staticmethod
    def get_used_tactic_indices(element):
        path = None
        if element.tag == 'excuse':
            path = 'communicativeTactics/communicativeTactic'
        elif element.tag == 'communicativeTactics':
            path = 'communicativeTactic'

        if path is None: return []
        return sorted([int(tactic.attrib['tacticIndex']) for tactic in element.findall(path)])
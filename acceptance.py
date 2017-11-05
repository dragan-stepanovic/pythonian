import unittest
import os


class AcceptanceTests(unittest.TestCase):
    def test_reports_success_on_build_success(self):
        self.setup_repo()
        self.invoke_build()
        result = self.get_result()
        self.assertTrue(result)

    def setup_repo(self):
        self.assert_local_repo_exits()

    def invoke_build(self):
        ci_server = CiServer()
        ci_server.start()

    def assert_local_repo_exits(self):
        if not os.path.isdir(r'C:\projects\pythonian\repo'):
            raise ValueError('repo folder does not exist')

    def get_result(self):
        if not os.path.isdir(r'C:\projects\pythonian\result'):
            raise ValueError('results folder does not exist')

        for dirpath, _, files in os.walk(r'C:\projects\pythonian\result'):
            if files:
                print(dirpath, 'has files')
                return True
            else:
                return False


class CiServer:
    def start(self):
        pass


if __name__ == '__main__':
    unittest.main()

import unittest


class AcceptanceTests(unittest.TestCase):
    def test_reports_success_on_build_success(self):
        self.setup_repo()
        self.invoke_build()
        report_checker = ReportChecker()
        result = report_checker.get_status()
        self.assertTrue(result)

    def setup_repo(self):
        pass

    def invoke_build(self):
        pass


class ReportChecker:
    def get_status(self):
        return False


if __name__ == '__main__':
    unittest.main()

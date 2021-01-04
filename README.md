# patting_server

**Unity로 구현한 partting 게임의 서버**

## 1. 사양

| 분류     | 사양                |
| :------- | :------------------ |
| cpu      | amd 2700X           |
| os       | Ubuntu 20.04(Linux) |
| db       | mysql(miria DB)     |
| language | C#                  |
| tool     | VSCode              |

## 2. 구조

```
partting_server
├── package (nuget 외부 패키치 모음)
│   ├── Extends Packages
│   └── ...
├── lib (기능 동작과 관련 있는 코드 모음)
│   ├── Connection.cs
│   └── Common_script
│   └── ...
├── util(에러 핸들러, 로그 설정 같은 기능 동작과 관련 없는 코드 모음)
│   └── Error_handler
│   └── log
│   └── config
├── log(로그 파일 모음)
│   └── 20201231.log
│   └── ...
├── db(직접 실행해야하는 sql문 모음)
│   └── Setup.sql
│   └── 20211120.sql
│   └── ...
├── Info.cs
├── controller
│   ├── RequestController.cs
│   ├── move.cs
│   └── ...
└── Main.cs
```

## 3. 역할

> 세환 : 서버 통신 설계 및 구현 담당 및 api 구현 보조.

> 성진 : api 구현 및 db 관리 담당.

## 4. 규칙

### 1) 브랜치 관련

> 브랜치는 dev-{기능이름} 으로 이름을 정한다.

> 만약 추가로 브랜치를 만들 경우 develop-{기능이름}-temp 로 이름을 정한다.

> 서버는 main merge 후 로그 관측, 실행 및 종료만 수행 한다.

> 서버는 main과 dev로 나누어 관리하며, dev 에서 테스트 후 main 에서 배포 한다.


### 2) merge 관련

> 해당 사용자는 merge 기능을 사용하지 않고 pull request(일명 PR)을 통해 다른 개발 참여자들을 통해 리뷰를 받고 모두가 승인 하면 merge 한다


### 3) 로그 관련

> 로그 파일은 하루에 한번씩 갱신 되며, 30일이 지나면 자동 파기 된다.

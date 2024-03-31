# MailApp

一个支持多个邮箱服务的, 基于 UWP, Fluent Design 风格的邮箱客户端

<br/>

## 项目结构

1. MailApp: 主项目
2. MailApp.Secrets: 存放机密信息的项目
3. MailApp.Secrets.SourceGenerator: 根据机密配置文件自动生成对应代码的源生成器

<br/>

## 构建

1. 保证你使用的是最新 Visual Studio, 项目使用了源生成器, 如果你使用的是旧版 VS, 例如 VS 2019,
   源生成器可能无法正常工作.
2. 配置 AppSecrets: 打开 MailApp.Secrets 项目, 你会看到一个 "AppSecrets.Template.ini" 的文件,
   根据该文件内提示, 创建一个 "AppSecrets.ini", 并在里面配置好对应的信息.
3. 直接开始构建 MailApp 项目.

> 注意: 不要在任何带有 Template 字样的文件中填入机密信息, 因为它被包含在版本控制中了
> AppSecrets.ini 不在版本控制中, 所以放心填写即可.

<br />

## 贡献

1. Fork 该项目
2. 做你想要的更改
3. 提交 Pull request

注意事项:

1. Commit message 必须带有概述前缀, 例如 "feat", "fix", "docs", 这些.
   包含不规范提交消息的 Pull request 一概不受理
2. 组织内人员, 如果你并不是该项目的管理员, 不要直接向此项目进行推送.